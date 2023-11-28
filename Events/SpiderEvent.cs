﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class SpiderEvent : GameEvent
    {
        AnimationCurve oldAnimationCurve;
        List<int> rarities = new List<int>();
        int oldMaxCount;

        public override string GetEventName()
        {
            return "Arachnophobia";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            oldAnimationCurve = newLevel.enemySpawnChanceThroughoutDay;
            newLevel.enemySpawnChanceThroughoutDay = new AnimationCurve(new Keyframe(0, 500f));

            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                rarities.Add(newLevel.Enemies[i].rarity);
                newLevel.Enemies[i].rarity = 0;
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<SandSpiderAI>() != null)
                {
                    newLevel.Enemies[i].rarity = 999;

                    oldMaxCount = newLevel.Enemies[i].enemyType.MaxCount;
                    newLevel.Enemies[i].enemyType.MaxCount = configs.SpiderEventSpiderMax.Value;
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            newLevel.enemySpawnChanceThroughoutDay = oldAnimationCurve;
            for (int i = 0; i < newLevel.Enemies.Count; i++)
            {
                newLevel.Enemies[i].rarity = rarities[i];
                if (newLevel.Enemies[i].enemyType.enemyPrefab.GetComponent<SandSpiderAI>() != null)
                {
                    newLevel.Enemies[i].enemyType.MaxCount = oldMaxCount;
                }
            }
        }

        public override bool IsValid(ref SelectableLevel newLevel)
        {
            foreach (var enemy in newLevel.Enemies)
            {
                if (enemy.enemyType.enemyPrefab.GetComponent<SandSpiderAI>() != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
