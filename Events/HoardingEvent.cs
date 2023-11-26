using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class HoardingEvent : GameEvent
    {
        AnimationCurve oldAnimationCurve;
        List<int> rarities = new List<int>();

        public override string GetEventName()
        {
            return "Kleptomania";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            oldAnimationCurve = newLevel.enemySpawnChanceThroughoutDay;
            newLevel.enemySpawnChanceThroughoutDay = new UnityEngine.AnimationCurve(new UnityEngine.Keyframe(0, 500f));

            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                rarities.Add(newLevel.Enemies[i].rarity);
                newLevel.Enemies[i].rarity = 0;
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<HoarderBugAI>() != null)
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
            foreach (var enemy in newLevel.Enemies)
            {
                if (enemy.enemyType.enemyPrefab.GetComponent<HoarderBugAI>() != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
