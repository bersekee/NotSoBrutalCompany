using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class WalkiDeliveryEvent : GameEvent
    {
        public override string GetEventName()
        {
            return "Walkie delivery";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            Terminal terminal2 = UnityEngine.Object.FindObjectOfType<Terminal>();
            int itemCount = terminal2.orderedItemsFromTerminal.Count;
            if (itemCount == 0)
            {
                itemCount = 1;
            }

            terminal2.orderedItemsFromTerminal.Clear();
            for (int i = 0; i < itemCount; i++)
            {
                terminal2.orderedItemsFromTerminal.Add(0);
            }
        }
    }
}
