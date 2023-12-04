using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class ThunderEventCreator : BrutalEventCreator
    {
        public override BrutalEvent Create()
        {
            return new ThunderEvent();
        }
    }

    class ThunderEvent : BrutalEvent
    {
        LevelWeatherType oldType;
        bool oldOverrideWeather;

        public override string GetEventName()
        {
            return "Thunderstruck";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel, ConfigSettings configs)
        {
            oldType = newLevel.overrideWeatherType;
            oldOverrideWeather = newLevel.overrideWeather;

            newLevel.currentWeather = LevelWeatherType.Stormy;
            newLevel.overrideWeather = false;
        }

        public override void OnLoadNewLevelCleanup(ref SelectableLevel newLevel)
        {
            newLevel.currentWeather = oldType;
            newLevel.overrideWeather = oldOverrideWeather;
        }
    }
}
