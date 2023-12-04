using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NotSoBrutalCompany.Events
{
    class TurretEventCreator : BrutalEventCreator
    {
        public override BrutalEvent Create()
        {
            return new TurretEvent();
        }
    }

    class TurretEvent : BrutalEvent
    {
        private AnimationCurve oldCurve;

        public override string GetEventName()
        {
            return "Turret hell";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            foreach (var item in newLevel.spawnableMapObjects)
            {
                if (item.prefabToSpawn.GetComponentInChildren<Turret>() != null)
                {
                    oldCurve = item.numberToSpawn;
                    item.numberToSpawn = new AnimationCurve(new Keyframe(0f, 100f), new Keyframe(1f, 13));
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
