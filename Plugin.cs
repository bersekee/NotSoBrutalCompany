using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using NotSoBrutalCompany.Events;
using NotSoBrutalCompany.Heat;
using System.Collections.Generic;
using UnityEngine;

namespace NotSoBrutalCompany
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool loaded;

        public static GameEvent gameEvent = null;
        public static EventCreator eventCreator = new EventCreator();

        public static HeatController heatController;

        public static SelectableLevel lastLevel = null;

        public static List<int> difficultyModifiedLevels = new List<int>();

        Harmony _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        public static ManualLogSource mls;

        private void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource("NotSoBrutalCompany");
            // Plugin startup logic
            mls.LogInfo("Loaded Not so Brutal Company and applying patches.");
            _harmony.PatchAll(typeof(Plugin));
            mls = Logger;

            heatController = new HeatController();
        }

        public void OnDestroy()
        {
            //mls.LogMessage("ugh");
        }

        [HarmonyPatch(typeof(TimeOfDay), "Start")]
        [HarmonyPrefix]
        static void QuotaAjuster(TimeOfDay __instance)
        {
            __instance.quotaVariables.startingQuota = 500;

            __instance.quotaVariables.startingCredits = 150;
            __instance.quotaVariables.baseIncrease = 275;
            //__instance.quotaVariables.randomizerMultiplier = 0;
            //__instance.quotaVariables.deadlineDaysAmount = 10;
        }

        [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.LoadNewLevel))]
        [HarmonyPrefix]
        static bool LoadNewLevel(ref SelectableLevel newLevel)
        {
            mls.LogInfo($"NotSoBrutalCompany logs");

            HUDManager.Instance.AddTextToChatOnServer("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            ChangeLevelDifficulty(ref newLevel);

            // Clean and get the event for the game.
            if (gameEvent != null)
            {
                gameEvent.OnLoadNewLevelCleanup(ref lastLevel);
            }

            if (newLevel.sceneName == "CompanyBuilding")
            {
                gameEvent = new NoneEvent();
            }
            else
            {
                do
                {
                    gameEvent = eventCreator.GetRandomEventWithWeight();
                }
                while (!gameEvent.IsValid(ref newLevel));
            }

            HUDManager.Instance.AddTextToChatOnServer($"<color=red>Level event:</color> <color=green>{gameEvent.GetEventName()}</color>");

            gameEvent.OnLoadNewLevel(ref newLevel);

            lastLevel = newLevel;

            //foreach (var enemy in newLevel.Enemies)
            //{
            //    mls.LogInfo($"SpawnChance: {enemy.enemyType.name}-{enemy.rarity}");
            //}
            //foreach (var key in newLevel.enemySpawnChanceThroughoutDay.keys)
            //{
            //    mls.LogInfo($"SpawnChanceKeyInside: {key.time}-{key.value}");
            //}
            //foreach (var key in newLevel.daytimeEnemySpawnChanceThroughDay.keys)
            //{
            //    mls.LogInfo($"SpawnChanceKeyOutside: {key.time}-{key.value}");
            //}
            return true;
        }

        static void ChangeLevelDifficulty(ref SelectableLevel newLevel)
        {
            if (difficultyModifiedLevels.Contains(newLevel.levelID))
                return;

            // Make level harder
            newLevel.minScrap += 0;
            newLevel.maxScrap += 45;
            newLevel.minTotalScrapValue += 0;
            newLevel.maxTotalScrapValue += 800;

            Keyframe[] keys = newLevel.daytimeEnemySpawnChanceThroughDay.GetKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].value += 0.5f;
            }
            newLevel.daytimeEnemySpawnChanceThroughDay.SetKeys(keys);

            keys = newLevel.enemySpawnChanceThroughoutDay.GetKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].value += 0.5f;
            }
            newLevel.enemySpawnChanceThroughoutDay.SetKeys(keys);

            newLevel.maxEnemyPowerCount += 2000;
            newLevel.maxOutsideEnemyPowerCount += 20;
            newLevel.maxDaytimeEnemyPowerCount += 200;

            difficultyModifiedLevels.Add(newLevel.levelID);
        }
    }
}