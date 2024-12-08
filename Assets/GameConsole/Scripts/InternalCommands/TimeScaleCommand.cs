using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace GameConsole
{
    internal class TimeScaleCommand : ConsoleCommand
    {
        public TimeScaleCommand() : base("TimeScale", "Scale")
        {
        }

        protected override string Invoke(List<string> arguments)
        {
            var scaleStr = arguments[0];
            scaleStr = scaleStr.Replace(',', '.');

            var scale = float.Parse(scaleStr, CultureInfo.InvariantCulture);
            Time.timeScale = scale;
            return $"Now Time.timeScale is {scale}";
        }
    }
}