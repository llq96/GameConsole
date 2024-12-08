using UnityEngine;

namespace GameConsole.Commands
{
    internal class TimeScaleCommand : GenericCommand_1<float>
    {
        public override string Word => "TimeScale";
        public override string Description => "Change TimeScale";

        public TimeScaleCommand() : base("Scale")
        {
        }

        protected override string GenericInvoke(float timeScale)
        {
            Time.timeScale = timeScale;
            return $"Now Time.timeScale is {timeScale}";
        }
    }
}