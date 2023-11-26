using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class LandmineEvent : GameEvent
    {
        private AnimationCurve oldCurve;

        public override string GetEventName()
        {
            return "Landmine hell";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            foreach (var item in newLevel.spawnableMapObjects)
            {
                if (item.prefabToSpawn.GetComponentInChildren<Landmine>() != null)
                {
                    oldCurve = item.numberToSpawn;
                    item.numberToSpawn = new AnimationCurve(new UnityEngine.Keyframe(0f, 300f), new UnityEngine.Keyframe(1f, 170f));
                }
            }
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            foreach (var item in newLevel.spawnableMapObjects)
            {
                if (item.prefabToSpawn.GetComponentInChildren<Turret>() != null)
                {
                    item.numberToSpawn = oldCurve;
                }
            }
        }
    }
}
