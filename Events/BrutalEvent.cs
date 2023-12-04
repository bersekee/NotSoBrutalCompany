using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    public abstract class BrutalEventCreator
    {
        public abstract BrutalEvent Create();
    }

    public abstract class BrutalEvent
    {
        public abstract string GetEventName();
        public abstract void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs);
        public virtual void OnLoadNewLevelCleanup(ref SelectableLevel newLevel) { }

        public virtual bool IsValid(ref SelectableLevel newLevel) { return true; }
    }
}
