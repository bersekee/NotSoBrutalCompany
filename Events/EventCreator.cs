using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    internal class EventCreator
    {
        List<BrutalEventCreator> customEventOrder = new List<BrutalEventCreator> { new JesterEventCreator(), new CoilHeadEventCreator(), new JesterEventCreator() };

        private int customCurrentIndex = 0;
        private int currentIndex = 0;

        public BrutalEvent GetRandomEvent()
        {
            List<BrutalEventCreator> events = BrutalEventList.GetEvents();
            Random random = new Random();
            BrutalEventCreator randomEvent = events[random.Next(events.Count)];
            return randomEvent.Create();
        }

        public BrutalEvent GetRandomEventWithWeight(int eventProbability)
        {
            Random random = new Random();
            int randomValue = random.Next(0, 10);
            if (randomValue < eventProbability)
            {
                return new NoneEvent();
            }

            return GetRandomEvent();
        }

        public BrutalEvent GetEventInOrder()
        {
            List<BrutalEventCreator> events = BrutalEventList.GetEvents();
            BrutalEventCreator currentEvent = events[currentIndex];
            currentIndex++;
            if (currentIndex >= events.Count)
            {
                currentIndex = 0;
            }
            return currentEvent.Create();
        }

        public BrutalEvent GetEventInCustomOrder()
        {
            BrutalEventCreator currentEvent = customEventOrder[customCurrentIndex];
            customCurrentIndex++;
            if (customCurrentIndex >= customEventOrder.Count)
            {
                customCurrentIndex = 0;
            }
            return currentEvent.Create();
        }
    }
}
