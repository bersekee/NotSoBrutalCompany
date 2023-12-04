using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    public static class BrutalEventList
    {
        private static List<BrutalEventCreator> events = new List<BrutalEventCreator>();

        public static List<BrutalEventCreator> GetEvents()
        {
            return events;
        }

        public static void AddEvent(BrutalEventCreator brutalEvent)
        {
            events.Add(brutalEvent);
        }

        internal static void AddBaseEvents(ConfigSettings configs)
        {
            if (configs.EnableFlowermanCoilEvent.Value)
            {
                AddEvent(new BrackenCoilEventCreator());
            }
            if (configs.EnableDogEvent.Value)
            {
                AddEvent(new DogEventCreator());
            }
            if (configs.EnableHoardingBugsEvent.Value)
            {
                AddEvent(new HoardingEventCreator());
            }
            if (configs.EnableJetpackEvent.Value)
            {
                AddEvent(new JetpackDeliveryCreator());
            }
            if (configs.EnableLandmineEvent.Value)
            {
                AddEvent(new LandmineEventCreator());
            }
            if (configs.EnableLassoEvent.Value)
            {
                AddEvent(new LassoEventCreator());
            }
            if (configs.EnableLittleGirlEvent.Value)
            {
                AddEvent(new LittleGirlEventCreator());
            }
            if (configs.EnableMonkeyEvent.Value)
            {
                AddEvent(new MonkeyEventCreator());
            }
            if (configs.EnableRandomDeliveryEvent.Value)
            {
                AddEvent(new RandomDeliveryEventCreator());
            }
            if (configs.EnableSnareFleaEvent.Value)
            {
                AddEvent(new SnareFleaEventCreator());
            }
            if (configs.EnableSpiderEvent.Value)
            {
                AddEvent(new SpiderEventCreator());
            }
            if (configs.EnableThumperEvent.Value)
            {
                AddEvent(new ThumperEventCreator());
            }
            if (configs.EnableThunderEvent.Value)
            {
                AddEvent(new ThunderEventCreator());
            }
            if (configs.EnableTurretEvent.Value)
            {
                AddEvent(new TurretEventCreator());
            }
            if (configs.EnableWalkiDeliveryEvent.Value)
            {
                AddEvent(new WalkiDeliveryEventCreator());
            }
            if (configs.EnableCoilHeadEvent.Value)
            {
                AddEvent(new CoilHeadEventCreator());
            }
            if (configs.EnableJesterEvent.Value)
            {
                AddEvent(new JesterEventCreator());
            }
        }
    }
}
