using UnityEngine;

namespace GameConsole.Commands
{
    internal class SetCameraColorCommand : GenericCommand_1<Color>
    {
        public override string Word => "SetCameraColor";
        public override string Description => "Change Camera Color";

        public SetCameraColorCommand() : base("Color")
        {
        }

        protected override string GenericInvoke(Color color)
        {
            Camera.main.backgroundColor = color;
            return $"Now Time.timeScale is {color}";
        }
    }
}