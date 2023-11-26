using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    public class EventCreator
    {
        List<EventEnum> customEventOrder = new List<EventEnum> { EventEnum.None };

        private int customCurrentIndex = 0;
        private int currentIndex = 0;

        public GameEvent GetRandomEvent()
        {
            Array values = Enum.GetValues(typeof(EventEnum));
            Random random = new Random();
            EventEnum randomEvent = (EventEnum)values.GetValue(random.Next(values.Length));
            return EnumToEvent(randomEvent);
        }

        public GameEvent GetRandomEventWithWeight()
        {
            Random random = new Random();
            int randomValue = random.Next(0, 10);
            if (randomValue < 3)
            {
                return new NoneEvent();
            }

            Array values = Enum.GetValues(typeof(EventEnum));
            EventEnum randomEvent = (EventEnum)values.GetValue(random.Next(values.Length));
            return EnumToEvent(randomEvent);
        }

        public GameEvent GetEventInOrder()
        {
            Array values = Enum.GetValues(typeof(EventEnum));
            EventEnum currentEvent = (EventEnum)values.GetValue(currentIndex);
            currentIndex++;
            if (currentIndex >= values.Length)
            {
                currentIndex = 0;
            }
            return EnumToEvent(currentEvent);
        }

        public GameEvent GetEventInCustomOrder()
        {
            EventEnum currentEvent = customEventOrder[customCurrentIndex];
            customCurrentIndex++;
            if (customCurrentIndex >= customEventOrder.Count)
            {
                customCurrentIndex = 0;
            }
            return EnumToEvent(currentEvent);
        }

        public GameEvent EnumToEvent(EventEnum eventEnum)
        {
            switch (eventEnum)
            {
                case EventEnum.None:
                    return new NoneEvent();
                case EventEnum.Turret:
                    return new TurretEvent();
                case EventEnum.Landmine:
                    return new LandmineEvent();
                case EventEnum.Hoarding:
                    return new HoardingEvent();
                case EventEnum.Lasso:
                    return new LassoEvent();
                case EventEnum.SnareFlea:
                    return new SnareFleaEvent();
                case EventEnum.BrackenAndCoil:
                    return new BrackenCoilEvent();
                case EventEnum.RandomDelivery:
                    return new RandomDeliveryEvent();
                case EventEnum.WalkiDelivery:
                    return new WalkiDeliveryEvent();
                case EventEnum.SpiderEvent:
                    return new SpiderEvent();
                case EventEnum.DogEvent:
                    return new DogEvent();
                case EventEnum.ThunderEvent:
                    return new ThunderEvent();
                case EventEnum.JetpackDelivery:
                    return new JetpackDelivery();
                case EventEnum.LittleGirl:
                    return new LittleGirlEvent();
                case EventEnum.Monkey:
                    return new MonkeyEvent();
            }

            //Default
            return new NoneEvent();
        }
    }
}
