using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    public class EventCreator
    {
        public GameEvent GetRandomEvent()
        {
            Array values = Enum.GetValues(typeof(EventEnum));
            Random random = new Random();
            EventEnum randomEvent = (EventEnum)values.GetValue(random.Next(values.Length));
            switch (randomEvent)
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
                default:
                    break;
            }

            //Default
            return new NoneEvent();
        }
    }
}
