using BepInEx;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany
{
    public class ConfigSettings
    {
        public ConfigEntry<int> StartingQuota { get; set; }
        public ConfigEntry<int> QuotaIncrease { get; set; }
        public ConfigEntry<int> StartingCredits { get; set; }
        public ConfigEntry<int> PassiveCredits { get; set; }
        public ConfigEntry<int> MinScrapModifier{ get; set; }
        public ConfigEntry<int> MaxScrapModifier { get; set; }
        public ConfigEntry<int> MinScrapValueModifier { get; set; }
        public ConfigEntry<int> MaxScrapValueModifier { get; set; }
        public ConfigEntry<int> MaxInsideEnemyPowerModifier { get; set; }
        public ConfigEntry<int> MaxOutsideEnemyPowerModifier { get; set; }
        public ConfigEntry<int> MaxDaytimeEnemyPowerModifier { get; set; }
        public ConfigEntry<float> InsideEnemySpawnCurve1 { get; set; }
        public ConfigEntry<float> InsideEnemySpawnCurve2 { get; set; }
        public ConfigEntry<float> OutsideEnemySpawnCurve1 { get; set; }
        public ConfigEntry<float> OutsideEnemySpawnCurve2 { get; set; }
        public ConfigEntry<float> OutsideEnemySpawnCurve3 { get; set; }
        public ConfigEntry<float> DaytimeEnemySpawnCurve1 { get; set; }
        public ConfigEntry<float> DaytimeEnemySpawnCurve2 { get; set; }
        public ConfigEntry<float> TurretSpawnCurve1 { get; set; }
        public ConfigEntry<float> TurretSpawnCurve2 { get; set; }
        public ConfigEntry<float> MineSpawnCurve1 { get; set; }
        public ConfigEntry<float> MineSpawnCurve2 { get; set; }
        public ConfigEntry<int> EventProbability { get; set; }
        public ConfigEntry<int> FlowermanCoilEventFlowermanMax { get; set; }
        public ConfigEntry<int> FlowermanCoilEventCoilHeadMax { get; set; }
        public ConfigEntry<int> HoardingBugsEventHoardingMax { get; set; }
        public ConfigEntry<int> SnareFleaEventSnareFleaMax { get; set; }
        public ConfigEntry<int> SpiderEventSpiderMax { get; set; }
        public ConfigEntry<int> ThumperEventThumperMax { get; set; }
        public ConfigEntry<int> JetpackEventJetpackCount { get; set; }


        public void LoadConfigs()
        {
            StartingQuota = Plugin.instance.Config.Bind<int>("Quota", "StartingQuota", 500, "Starting quota.");
            QuotaIncrease = Plugin.instance.Config.Bind<int>("Quota", "QuotaIncrease", 275, "Quota increase after the dealine.");

            StartingCredits = Plugin.instance.Config.Bind<int>("Credits", "StartingCredits", 80, "Starting credits.");
            PassiveCredits = Plugin.instance.Config.Bind<int>("Credits", "PassiveCredits", 120, "Passive credits at the start of every level.");

            MinScrapModifier = Plugin.instance.Config.Bind<int>("Scraps", "MinScrapModifier", 0, "Added to the minimum total number of scraps in a level.");
            MaxScrapModifier = Plugin.instance.Config.Bind<int>("Scraps", "MaxScrapModifier", 45, "Added to the maximum total number of scraps in a level.");
            MinScrapValueModifier = Plugin.instance.Config.Bind<int>("Scraps", "MinScrapValueModifier", 0, "Added to the minimum total value of scraps in a level.");
            MaxScrapValueModifier = Plugin.instance.Config.Bind<int>("Scraps", "MaxScrapValueModifier", 800, "Added to the maximum total value of scraps in a level.");

            MaxInsideEnemyPowerModifier = Plugin.instance.Config.Bind<int>("Enemies", "MaxInsideEnemyPowerModifier", 2000, "Added to the maximum enemy power for inside enemies, this controls the maximum level difficulty.");
            MaxOutsideEnemyPowerModifier = Plugin.instance.Config.Bind<int>("Enemies", "MaxOutsideEnemyPowerModifier", 20, "Added to the maximum enemy power for outside enemies, this controls the maximum level difficulty.");
            MaxDaytimeEnemyPowerModifier = Plugin.instance.Config.Bind<int>("Enemies", "MaxDaytimeEnemyPowerModifier", 200, "Added to the maximum enemy power for daytime enemies, this controls the maximum level difficulty.");

            InsideEnemySpawnCurve1 = Plugin.instance.Config.Bind<float>("Enemies", "InsideEnemySpawnCurveValue1", 0.1f, "Spawn curve for inside enemies, start of the day.");
            InsideEnemySpawnCurve2 = Plugin.instance.Config.Bind<float>("Enemies", "InsideEnemySpawnCurveValue2", 500.0f, "Spawn curve for inside enemies, midday.");

            OutsideEnemySpawnCurve1 = Plugin.instance.Config.Bind<float>("Enemies", "OutsideEnemySpawnCurve1", -30.0f, "Spawn curve for outside enemies, start of the day.");
            OutsideEnemySpawnCurve2 = Plugin.instance.Config.Bind<float>("Enemies", "OutsideEnemySpawnCurve2", -30.0f, "Spawn curve for outside enemies, 4 hours bfore launch.");
            OutsideEnemySpawnCurve3 = Plugin.instance.Config.Bind<float>("Enemies", "OutsideEnemySpawnCurve3", 10.0f, "Spawn curve for outside enemies, 3 hours before launch");

            DaytimeEnemySpawnCurve1 = Plugin.instance.Config.Bind<float>("Enemies", "DaytimeEnemySpawnCurve1", 7.0f, "Spawn curve for daytime enemies, start of the day.");
            DaytimeEnemySpawnCurve2 = Plugin.instance.Config.Bind<float>("Enemies", "DaytimeEnemySpawnCurve2", 7.0f, "Spawn curve for daytime enemies, midday.");

            TurretSpawnCurve1 = Plugin.instance.Config.Bind<float>("Hazards", "TurretSpawnCurve1", 0.0f, "Spawn curve for turrets, first value. Increase the number of turrets in levels.");
            TurretSpawnCurve2 = Plugin.instance.Config.Bind<float>("Hazards", "TurretSpawnCurve2", 10.0f, "Spawn curve for turrets, second value. Increase the number of turrets in levels.");

            MineSpawnCurve1 = Plugin.instance.Config.Bind<float>("Hazards", "MineSpawnCurve1", 0.0f, "Spawn curve for mines, first value. Increase the number of mines in levels.");
            MineSpawnCurve2 = Plugin.instance.Config.Bind<float>("Hazards", "MineSpawnCurve2", 70.0f, "Spawn curve for mines, second value. Increase the number of mines in levels.");

            EventProbability = Plugin.instance.Config.Bind<int>("Events", "EventProbablity", 4, "Value from 0 to 10. 0 there's almost always an event and 10 there's never an event.");

            FlowermanCoilEventFlowermanMax = Plugin.instance.Config.Bind<int>("FlowermanCoilEvent", "FlowermanCoilEventFlowermanMax", 4, "Maximum number of flowerman during the event (capped by power modifier).");
            FlowermanCoilEventCoilHeadMax = Plugin.instance.Config.Bind<int>("FlowermanCoilEvent", "FlowermanCoilEventCoilHeadMax", 5, "Maximum number of coil head during the event (capped by power modifier).");

            HoardingBugsEventHoardingMax = Plugin.instance.Config.Bind<int>("HoardingBugsEvent", "HoardingBugsEventHoardingMax", 15, "Maximum number of hoarding bugs during the event (capped by power modifier).");

            SnareFleaEventSnareFleaMax = Plugin.instance.Config.Bind<int>("SnareFleaEvent", "SnareFleaEventSnareFleaMax", 6, "Maximum number of snare flea during the event (capped by power modifier).");
            
            SpiderEventSpiderMax = Plugin.instance.Config.Bind<int>("SpiderEvent", "SpiderEventSpiderMax", 6, "Maximum number of spiders during the event (capped by power modifier).");
            
            ThumperEventThumperMax = Plugin.instance.Config.Bind<int>("ThumperEvent", "ThumperEventThumperMax", 6, "Maximum number of thumper during the event (capped by power modifier).");

            JetpackEventJetpackCount = Plugin.instance.Config.Bind<int>("JetpackEvent", "JetpackEventJetpackCount", 5, "Number of jetpacks during jetpack event.");

        }
    }
}
