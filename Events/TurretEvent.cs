using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class TurretEvent : GameEvent
    {
        private AnimationCurve oldCurve;

        public override string GetEventName()
        {
            return "Turret hell";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
        {
            foreach (var item in newLevel.spawnableMapObjects)
            {
                if (item.prefabToSpawn.GetComponentInChildren<Turret>() != null)
                {
                    oldCurve = item.numberToSpawn;
                    item.numberToSpawn = new AnimationCurve(new UnityEngine.Keyframe(0f, 200f), new UnityEngine.Keyframe(1f, 25));
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
