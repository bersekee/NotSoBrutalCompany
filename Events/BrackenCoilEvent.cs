using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class BrackenCoilEvent : GameEvent
    {
        List<int> rarities = new List<int>();

        public override string GetEventName()
        {
            return "The deadliest combo of all time";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                rarities.Add(newLevel.Enemies[i].rarity);
                newLevel.Enemies[i].rarity = 0;
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<FlowermanAI>() != null)
                {
                    newLevel.Enemies[i].rarity = 999;
                }
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<SpringManAI>() != null)
                {
                    newLevel.Enemies[i].rarity = 999;
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                newLevel.Enemies[i].rarity = rarities[i];
            }
        }
    }
}
