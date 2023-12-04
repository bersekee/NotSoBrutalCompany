using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

namespace NotSoBrutalCompany.Events
{
    class RandomDeliveryEventCreator : BrutalEventCreator
    {
        public override BrutalEvent Create()
        {
            return new RandomDeliveryEvent();
        }
    }

    class RandomDeliveryEvent : BrutalEvent
    {
        public override string GetEventName()
        {
            return "Lost delivery";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            int randItemCount = Random.Range(2, 9);
            for (int i = 0; i < randItemCount; i++)
            {
                int randomItemID = Random.Range(0, 6);
                Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
                terminal.orderedItemsFromTerminal.Add(randomItemID);
            }
        }
    }
}
