using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class GoldMineEvent : BrutalEvent
    {
        public override string GetEventName()
        {
            return "Gold Mine";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            foreach (var item in newLevel.spawnableScrap)
            {
                //item.spawnableItem.
            }
        }
    }
}
