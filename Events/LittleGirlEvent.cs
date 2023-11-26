using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class LittleGirlEvent : GameEvent
    {
        int oldRarity;

        public override string GetEventName()
        {
            return "Sweet Little Girl";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<DressGirlAI>() != null)
                {
                    oldRarity = newLevel.Enemies[i].rarity;
                    newLevel.Enemies[i].rarity = 999;
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<DressGirlAI>() != null)
                {
                    oldRarity = newLevel.Enemies[i].rarity;
                }
            }
        }
    }
}
