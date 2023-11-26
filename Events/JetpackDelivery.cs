using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class JetpackDelivery : GameEvent
    {
        public override string GetEventName()
        {
            return "Jetpack delivery (maybe)";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            int quantity = 5;
            int jetPackId = 5;

            Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
            for (int i = 0; i < quantity; i++)
            {
                terminal.orderedItemsFromTerminal.Add(jetPackId);
            }
        }
    }
}
