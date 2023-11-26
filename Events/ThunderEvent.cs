using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoBrutalCompany.Events
{
    class ThunderEvent : GameEvent
    {
        LevelWeatherType oldType;
        bool oldOverrideWeather;

        public override string GetEventName()
        {
            return "Thunderstruck";
        }

        public override void OnLoadNewLevel(ref SelectableLevel newLevel)
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
