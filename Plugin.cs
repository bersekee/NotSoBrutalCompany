using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using NotSoBrutalCompany.Component;
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
            if (!loaded)
            {
                GameObject gameObject = new GameObject("QuotaChanger");
                DontDestroyOnLoad(gameObject);
                gameObject.AddComponent<QuotaAjuster>();
                //mls.LogMessage("Created the gameobject!");
                loaded = true;
                //LC_API.ServerAPI.ModdedServer.SetServerModdedOnly();
            }
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
                gameEvent.OnLoadNewLevelCleanup(ref newLevel);
            }

            if (newLevel.sceneName == "CompanyBuilding")
            {
                gameEvent = new NoneEvent();
            }
            else
            {
                //EventCreator creator = new EventCreator();
                //gameEvent = creator.GetRandomEvent();
                gameEvent = new DogEvent();
            }

            HUDManager.Instance.AddTextToChatOnServer($"<color=red>Level event:</color> <color=green>{gameEvent.GetEventName()}</color>");

            gameEvent.OnLoadNewLevel(ref newLevel);

            lastLevel = newLevel;

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

            newLevel.daytimeEnemySpawnChanceThroughDay = new UnityEngine.AnimationCurve(new UnityEngine.Keyframe(0, 7f), new Keyframe(0.5f, 7));

            newLevel.maxEnemyPowerCount += 2000;
            newLevel.maxOutsideEnemyPowerCount += 20;
            newLevel.maxDaytimeEnemyPowerCount += 200;

            difficultyModifiedLevels.Add(newLevel.levelID);

            mls.LogInfo("New level values: Factory size - " + newLevel.factorySizeMultiplier + " MinScrap - " + newLevel.minScrap + " MaxScrap - " + newLevel.maxScrap + " MinTotalScrapValue - " + newLevel.minTotalScrapValue + " MaxTotalScrapValue - " + newLevel.maxTotalScrapValue + " SpawnChance - " + newLevel.enemySpawnChanceThroughoutDay);
        }
    }
}