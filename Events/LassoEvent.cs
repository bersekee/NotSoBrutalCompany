using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class LassoEventCreator : BrutalEventCreator
    {
        public override BrutalEvent Create()
        {
            return new LassoEvent();
        }
    }

    class LassoEvent : BrutalEvent
    {
        public override string GetEventName()
        {
            return "Lasso man is real";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            bool gotLasso = false;
            bool addedLasso = false;
            foreach (var item in newLevel.Enemies)
            {
                if (item.enemyType.enemyPrefab.GetComponent<LassoManAI>() != null)
                {
                    gotLasso = true;
                }
            }
            if (!gotLasso)
            {
                foreach (var level in StartOfRound.Instance.levels)
                {
                    foreach (var enemy in level.Enemies)
                    {
                        if (enemy.enemyType.enemyPrefab.GetComponent<LassoManAI>() != null)
                        {
                            if (!addedLasso)
                            {
                                addedLasso = true;
                                newLevel.Enemies.Add(enemy);
                            }
                        }
                    }
                }

            }
            foreach (var item in newLevel.Enemies)
            {
                if (item.enemyType.enemyPrefab.GetComponent<LassoManAI>() != null)
                {
                    item.rarity = 999;
                    item.enemyType.probabilityCurve = new AnimationCurve(new Keyframe(0, 10000));
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            for (int i = newLevel.Enemies.Count - 1; i >= 0; i--)
            {
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<LassoManAI>() != null)
                {
                    newLevel.Enemies.RemoveAt(i);
                }
            }
        }
    }
}
