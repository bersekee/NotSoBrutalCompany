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
        public ConfigEntry<bool> EnableDeadlineModification { get; set; }
        public ConfigEntry<int> DeadlineDays { get; set; }
        public ConfigEntry<bool> EnableQuotaModification { get; set; }
        public ConfigEntry<int> StartingQuota { get; set; }
        public ConfigEntry<int> QuotaIncrease { get; set; }
        public ConfigEntry<bool> EnableCreditModification { get; set; }
        public ConfigEntry<int> StartingCredits { get; set; }
        public ConfigEntry<int> PassiveCredits { get; set; }
        public ConfigEntry<bool> EnableScrapModification { get; set; }
        public ConfigEntry<int> MinScrapModifier{ get; set; }
        public ConfigEntry<int> MaxScrapModifier { get; set; }
        public ConfigEntry<int> MinScrapValueModifier { get; set; }
        public ConfigEntry<int> MaxScrapValueModifier { get; set; }
        public ConfigEntry<bool> EnableEnemyModification { get; set; }
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
        public ConfigEntry<bool> EnableHazardModification { get; set; }
        public ConfigEntry<float> TurretSpawnCurve1 { get; set; }
        public ConfigEntry<float> TurretSpawnCurve2 { get; set; }
        public ConfigEntry<float> MineSpawnCurve1 { get; set; }
        public ConfigEntry<float> MineSpawnCurve2 { get; set; }
        public ConfigEntry<bool> EventHidden { get; set; }
        public ConfigEntry<int> EventProbability { get; set; }
        public ConfigEntry<bool> EnableFlowermanCoilEvent { get; set; }
        public ConfigEntry<int> FlowermanCoilEventFlowermanMax { get; set; }
        public ConfigEntry<int> FlowermanCoilEventCoilHeadMax { get; set; }
        public ConfigEntry<bool> EnableDogEvent { get; set; }
        public ConfigEntry<bool> EnableHoardingBugsEvent { get; set; }
        public ConfigEntry<int> HoardingBugsEventHoardingMax { get; set; }
        public ConfigEntry<bool> EnableJetpackEvent { get; set; }
        public ConfigEntry<int> JetpackEventJetpackCount { get; set; }
        public ConfigEntry<bool> EnableLandmineEvent { get; set; }
        public ConfigEntry<bool> EnableLassoEvent { get; set; }
        public ConfigEntry<bool> EnableLittleGirlEvent { get; set; }
        public ConfigEntry<bool> EnableMonkeyEvent { get; set; }
        public ConfigEntry<bool> EnableRandomDeliveryEvent { get; set; }
        public ConfigEntry<bool> EnableSnareFleaEvent { get; set; }
        public ConfigEntry<int> SnareFleaEventSnareFleaMax { get; set; }
        public ConfigEntry<bool> EnableSpiderEvent { get; set; }
        public ConfigEntry<int> SpiderEventSpiderMax { get; set; }
        public ConfigEntry<bool> EnableThumperEvent { get; set; }
        public ConfigEntry<int> ThumperEventThumperMax { get; set; }
        public ConfigEntry<bool> EnableThunderEvent { get; set; }
        public ConfigEntry<bool> EnableTurretEvent { get; set; }
        public ConfigEntry<bool> EnableWalkiDeliveryEvent { get; set; }
        public ConfigEntry<bool> EnableCoilHeadEvent { get; set; }
        public ConfigEntry<int> CoilHeadEventCoilHeadMax { get; set; }
        public ConfigEntry<bool> EnableJesterEvent { get; set; }
        public ConfigEntry<int> JesterEventJesterMax { get; set; }


        public void LoadConfigs()
        {
            EnableDeadlineModification = Plugin.instance.Config.Bind<bool>("Deadline", "DeadlineModification", false, "False to go back to vanilla dealine value or avoid conflicting with other mods.");
            DeadlineDays = Plugin.instance.Config.Bind<int>("Deadline", "DeadlineDays", 3, "Days until deadline.");

            EnableQuotaModification = Plugin.instance.Config.Bind<bool>("Quota", "EnableQuotaModification", true, "False to go back to vanilla quota values or avoid conflicting with other mods.");
            StartingQuota = Plugin.instance.Config.Bind<int>("Quota", "StartingQuota", 500, "Starting quota.");
            QuotaIncrease = Plugin.instance.Config.Bind<int>("Quota", "QuotaIncrease", 275, "Quota increase after the dealine.");

            EnableCreditModification = Plugin.instance.Config.Bind<bool>("Credits", "EnableCreditModification", true, "False to go back to vanilla credit values or avoid conflicting with other mods.");
            StartingCredits = Plugin.instance.Config.Bind<int>("Credits", "StartingCredits", 80, "Starting credits.");
            PassiveCredits = Plugin.instance.Config.Bind<int>("Credits", "PassiveCredits", 120, "Passive credits at the start of every level.");

            EnableScrapModification = Plugin.instance.Config.Bind<bool>("Scraps", "EnableScrapModification", true, "False to go back to vanilla scrap values or avoid conflicting with other mods.");
            MinScrapModifier = Plugin.instance.Config.Bind<int>("Scraps", "MinScrapModifier", 0, "Added to the minimum total number of scraps in a level.");
            MaxScrapModifier = Plugin.instance.Config.Bind<int>("Scraps", "MaxScrapModifier", 45, "Added to the maximum total number of scraps in a level.");
            MinScrapValueModifier = Plugin.instance.Config.Bind<int>("Scraps", "MinScrapValueModifier", 0, "Added to the minimum total value of scraps in a level.");
            MaxScrapValueModifier = Plugin.instance.Config.Bind<int>("Scraps", "MaxScrapValueModifier", 800, "Added to the maximum total value of scraps in a level.");

            EnableEnemyModification = Plugin.instance.Config.Bind<bool>("Enemies", "EnableEnemyModification", true, "False to go back to vanilla enemy values or avoid conflicting with other mods.");

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

            EnableHazardModification = Plugin.instance.Config.Bind<bool>("Hazards", "EnableHazardModification", true, "False to go back to vanilla hazard values or avoid conflicting with other mods.");
            TurretSpawnCurve1 = Plugin.instance.Config.Bind<float>("Hazards", "TurretSpawnCurve1", 0.0f, "Spawn curve for turrets, first value. Increase the number of turrets in levels.");
            TurretSpawnCurve2 = Plugin.instance.Config.Bind<float>("Hazards", "TurretSpawnCurve2", 10.0f, "Spawn curve for turrets, second value. Increase the number of turrets in levels.");
            MineSpawnCurve1 = Plugin.instance.Config.Bind<float>("Hazards", "MineSpawnCurve1", 0.0f, "Spawn curve for mines, first value. Increase the number of mines in levels.");
            MineSpawnCurve2 = Plugin.instance.Config.Bind<float>("Hazards", "MineSpawnCurve2", 70.0f, "Spawn curve for mines, second value. Increase the number of mines in levels.");

            EventHidden = Plugin.instance.Config.Bind<bool>("Events", "EventHidden", false, "Set to true to hide events in the chat.");
            EventProbability = Plugin.instance.Config.Bind<int>("Events", "EventProbablity", 4, "Value from 0 to 10. 0 there's almost always an event and 10 there's never an event.");

            EnableFlowermanCoilEvent = Plugin.instance.Config.Bind<bool>("FlowermanCoilEvent", "EnableFlowermanCoilEvent", true, "Is the flowerman and coil (The deadliest combo of all time) event active.");
            FlowermanCoilEventFlowermanMax = Plugin.instance.Config.Bind<int>("FlowermanCoilEvent", "FlowermanCoilEventFlowermanMax", 3, "Maximum number of flowerman during the event (capped by power modifier).");
            FlowermanCoilEventCoilHeadMax = Plugin.instance.Config.Bind<int>("FlowermanCoilEvent", "FlowermanCoilEventCoilHeadMax", 5, "Maximum number of coil head during the event (capped by power modifier).");

            EnableDogEvent = Plugin.instance.Config.Bind<bool>("DogEvent", "EnableDogEvent", true, "Is the dog event(Who let the dogs out) active.");

            EnableHoardingBugsEvent = Plugin.instance.Config.Bind<bool>("HoardingBugsEvent", "EnableHoardingBugsEvent", true, "Is the hoarding bugs event(Kleptomania) active.");
            HoardingBugsEventHoardingMax = Plugin.instance.Config.Bind<int>("HoardingBugsEvent", "HoardingBugsEventHoardingMax", 15, "Maximum number of hoarding bugs during the event (capped by power modifier).");

            EnableJetpackEvent = Plugin.instance.Config.Bind<bool>("JetpackEvent", "EnableJetpackEvent", true, "Is the hoarding jetpack event(Jetpack delivery) active.");
            JetpackEventJetpackCount = Plugin.instance.Config.Bind<int>("JetpackEvent", "JetpackEventJetpackCount", 5, "Number of jetpacks during jetpack event.");

            EnableLandmineEvent = Plugin.instance.Config.Bind<bool>("LandmineEvent", "EnableLandmineEvent", true, "Is the landmine event(Landmine hell) active.");

            EnableLassoEvent = Plugin.instance.Config.Bind<bool>("LassoEvent", "EnableLassoEvent", true, "Is the lasso event(Lasso man is real) active.");

            EnableLittleGirlEvent = Plugin.instance.Config.Bind<bool>("LittleGirlEvent", "EnableLittleGirlEvent", true, "Is the little girl event(Sweet Little Girl) active.");

            EnableMonkeyEvent = Plugin.instance.Config.Bind<bool>("MonkeyEvent", "EnableMonkeyEvent", true, "Is the monkey event(Monke) active.");

            EnableRandomDeliveryEvent = Plugin.instance.Config.Bind<bool>("RandomDeliveryEvent", "EnableRandomDeliveryEvent", true, "Is the random delivery event(Lost delivery) active.");

            EnableSnareFleaEvent = Plugin.instance.Config.Bind<bool>("SnareFleaEvent", "EnableSnareFleaEvent", true, "Is the snare flea event(Ready to suffocate ?) active.");
            SnareFleaEventSnareFleaMax = Plugin.instance.Config.Bind<int>("SnareFleaEvent", "SnareFleaEventSnareFleaMax", 6, "Maximum number of snare flea during the event (capped by power modifier).");

            EnableSpiderEvent = Plugin.instance.Config.Bind<bool>("SpiderEvent", "EnableSpiderEvent", true, "Is the spider event(Arachnophobia) active.");
            SpiderEventSpiderMax = Plugin.instance.Config.Bind<int>("SpiderEvent", "SpiderEventSpiderMax", 6, "Maximum number of spiders during the event (capped by power modifier).");

            EnableThumperEvent = Plugin.instance.Config.Bind<bool>("ThumperEvent", "EnableThumperEvent", true, "Is the thumper event(Thump Thump Thump) active.");
            ThumperEventThumperMax = Plugin.instance.Config.Bind<int>("ThumperEvent", "ThumperEventThumperMax", 6, "Maximum number of thumper during the event (capped by power modifier).");

            EnableThunderEvent = Plugin.instance.Config.Bind<bool>("ThunderEvent", "EnableThunderEvent", true, "Is the thunder event(Thunderstruck) active.");
            
            EnableTurretEvent = Plugin.instance.Config.Bind<bool>("TurretEvent", "EnableTurretEvent", true, "Is the turret event(Turret hell) active.");
            
            EnableWalkiDeliveryEvent = Plugin.instance.Config.Bind<bool>("WalkiDeliveryEvent", "EnableWalkiDeliveryEvent", true, "Is the walki delivery event(Walkie delivery) active.");

            EnableCoilHeadEvent = Plugin.instance.Config.Bind<bool>("CoilHeadEvent", "EnableCoilHeadEvent", true, "Is the coil head event(Boing!) active.");
            CoilHeadEventCoilHeadMax = Plugin.instance.Config.Bind<int>("CoilHeadEvent", "CoilHeadEventCoilHeadMax", 5, "Maximum number of coil head during the event (capped by power modifier).");

            EnableJesterEvent = Plugin.instance.Config.Bind<bool>("JesterEvent", "EnableJesterEvent", true, "Is the jester event(Thump Thump Thump) active.");
            JesterEventJesterMax = Plugin.instance.Config.Bind<int>("JesterEvent", "JesterEventJesterMax", 4, "Maximum number of jester during the event (capped by power modifier).");
        }
    }
}
