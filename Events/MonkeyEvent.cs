using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class MonkeyEvent : GameEvent
    {
        AnimationCurve oldOutsideSpawnChance;
        List<int> rarities = new List<int>();

        public override string GetEventName()
        {
            return "Monke";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            oldOutsideSpawnChance = newLevel.outsideEnemySpawnChanceThroughDay;
            newLevel.outsideEnemySpawnChanceThroughDay = new AnimationCurve(new Keyframe(0, 3), new Keyframe(20f, 3), new Keyframe(21f, 3));

            for (int i = 0; i < newLevel.OutsideEnemies.Count; i++)
            {
                rarities.Add(newLevel.OutsideEnemies[i].rarity);
                newLevel.OutsideEnemies[i].rarity = 0;
                if (newLevel.OutsideEnemies[i].enemyType.enemyPrefab.GetComponent<BaboonBirdAI>() != null)
                {
                    newLevel.OutsideEnemies[i].rarity = 999;
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            newLevel.outsideEnemySpawnChanceThroughDay = oldOutsideSpawnChance;
            for (int i = 0; i < newLevel.OutsideEnemies.Count; i++)
            {
                newLevel.OutsideEnemies[i].rarity = rarities[i];
            }
        }

        public override bool IsValid(ref SelectableLevel newLevel)
        {
            foreach (var enemy in newLevel.OutsideEnemies)
            {
                if (enemy.enemyType.enemyPrefab.GetComponent<BaboonBirdAI>() != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
