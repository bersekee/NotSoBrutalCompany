using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
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
        public static Plugin instance;
        public static ConfigSettings configSettings = new ConfigSettings();

        public static bool loaded;

        public static GameEvent gameEvent = null;
        public static EventCreator eventCreator = new EventCreator();

        public static SelectableLevel lastLevel = null;

        public static List<int> difficultyModifiedLevels = new List<int>();

        Harmony _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        public static ManualLogSource mls;

        private void Awake()
        {
            instance = this;

            configSettings.LoadConfigs();

            mls = BepInEx.Logging.Logger.CreateLogSource("NotSoBrutalCompany");
            // Plugin startup logic
            mls.LogInfo("Loaded Not so Brutal Company and applying patches.");
            _harmony.PatchAll(typeof(Plugin));
            mls = Logger;
        }

        public void OnDestroy()
        {
            //mls.LogMessage("ugh");
        }


        [HarmonyPatch(typeof(TimeOfDay), "Awake")]
        [HarmonyPrefix]
        static void QuotaAjuster(TimeOfDay __instance)
        {
            __instance.quotaVariables.startingQuota = configSettings.StartingQuota.Value;

            __instance.quotaVariables.startingCredits = configSettings.StartingCredits.Value;
            __instance.quotaVariables.baseIncrease = configSettings.QuotaIncrease.Value;
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
                // Add credits
                Terminal terminal = FindObjectOfType<Terminal>();
                terminal.groupCredits += configSettings.PassiveCredits.Value;

                do
                {
                    gameEvent = eventCreator.GetRandomEventWithWeight(configSettings.EventProbability.Value);
                }
                while (!gameEvent.IsValid(ref newLevel));
            }

            HUDManager.Instance.AddTextToChatOnServer($"<color=red>Level event:</color> <color=green>{gameEvent.GetEventName()}</color>");

            gameEvent.OnLoadNewLevel(ref newLevel, configSettings);

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
            newLevel.minScrap += configSettings.MinScrapModifier.Value;
            newLevel.maxScrap += configSettings.MaxScrapModifier.Value;
            newLevel.minTotalScrapValue += configSettings.MinScrapValueModifier.Value;
            newLevel.maxTotalScrapValue += configSettings.MaxScrapValueModifier.Value;

            foreach (var item in newLevel.spawnableMapObjects)
            {
                if (item.prefabToSpawn.GetComponentInChildren<Turret>() != null)
                {
                    item.numberToSpawn = new AnimationCurve(new Keyframe(0f, configSettings.TurretSpawnCurve1.Value), new Keyframe(1f, configSettings.TurretSpawnCurve2.Value));
                }
                else if(item.prefabToSpawn.GetComponentInChildren<Landmine>() != null)
                {
                    item.numberToSpawn = new AnimationCurve(new Keyframe(0f, configSettings.MineSpawnCurve1.Value), new Keyframe(1f, configSettings.MineSpawnCurve2.Value));
                }
            }

            newLevel.enemySpawnChanceThroughoutDay = new AnimationCurve(new Keyframe(0, configSettings.InsideEnemySpawnCurve1.Value), new Keyframe(0.5f, configSettings.InsideEnemySpawnCurve2.Value));
            newLevel.daytimeEnemySpawnChanceThroughDay = new AnimationCurve(new Keyframe(0, configSettings.DaytimeEnemySpawnCurve1.Value), new Keyframe(0.5f, configSettings.DaytimeEnemySpawnCurve2.Value));
            newLevel.outsideEnemySpawnChanceThroughDay = new AnimationCurve(new Keyframe(0, configSettings.OutsideEnemySpawnCurve1.Value), new Keyframe(20f, configSettings.OutsideEnemySpawnCurve2.Value), new Keyframe(21f, configSettings.OutsideEnemySpawnCurve3.Value));

            newLevel.maxEnemyPowerCount += configSettings.MaxInsideEnemyPowerModifier.Value;
            newLevel.maxOutsideEnemyPowerCount += configSettings.MaxOutsideEnemyPowerModifier.Value;
            newLevel.maxDaytimeEnemyPowerCount += configSettings.MaxDaytimeEnemyPowerModifier.Value;

            difficultyModifiedLevels.Add(newLevel.levelID);
        }
    }
}