using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class JetpackDeliveryCreator : BrutalEventCreator
    {
        public override BrutalEvent Create()
        {
            return new JetpackDelivery();
        }
    }

    class JetpackDelivery : BrutalEvent
    {
        public override string GetEventName()
        {
            return "Jetpack delivery";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            int quantity = configs.JetpackEventJetpackCount.Value;
            int jetPackId = 9;

            Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
            for (int i = 0; i < quantity; i++)
            {
                terminal.orderedItemsFromTerminal.Add(jetPackId);
            }
        }
    }
}
