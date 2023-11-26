using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class BrackenCoilEvent : GameEvent
    {
        AnimationCurve oldAnimationCurve;
        List<int> rarities = new List<int>();

        public override string GetEventName()
        {
            return "The deadliest combo of all time";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            oldAnimationCurve = newLevel.enemySpawnChanceThroughoutDay;
            newLevel.enemySpawnChanceThroughoutDay = new AnimationCurve(new UnityEngine.Keyframe(0, 500f));

            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                rarities.Add(newLevel.Enemies[i].rarity);
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
            newLevel.enemySpawnChanceThroughoutDay = oldAnimationCurve;
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                newLevel.Enemies[i].rarity = rarities[i];
            }
        }

        public override bool IsValid(ref SelectableLevel newLevel)
        {
            bool flowerManFound = false;
            bool springManFound = false;
            foreach (var enemy in newLevel.Enemies)
            {
                if (enemy.enemyType.enemyPrefab.GetComponent<FlowermanAI>() != null)
                {
                    flowerManFound = true;
                }
                else if (enemy.enemyType.enemyPrefab.GetComponent<SpringManAI>() != null)
                {
                    springManFound = true;
                }
            }
            if (flowerManFound && springManFound)
            {
                return true;
            }
            return false;
        }
    }
}
