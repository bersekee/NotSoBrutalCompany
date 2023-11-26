using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class DogEvent : GameEvent
    {
        AnimationCurve oldOutsideSpawnChance;
        List<int> rarities = new List<int>();

        public override string GetEventName()
        {
            return "Who let the dogs out";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            oldOutsideSpawnChance = newLevel.outsideEnemySpawnChanceThroughDay;
            newLevel.outsideEnemySpawnChanceThroughDay = new AnimationCurve(new Keyframe(0, 3), new Keyframe(20f, 3), new Keyframe(21f, 3));

            for (int i = 0; i < newLevel.OutsideEnemies.Count; i++)
            {
                rarities.Add(newLevel.OutsideEnemies[i].rarity);
                newLevel.OutsideEnemies[i].rarity = 0;
                if (newLevel.OutsideEnemies[i].enemyType.enemyPrefab.GetComponent<MouthDogAI>() != null)
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
    }
}
