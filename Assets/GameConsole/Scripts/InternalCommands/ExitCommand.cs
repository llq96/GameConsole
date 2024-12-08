using System.Collections.Generic;

namespace GameConsole
{
    internal class ExitCommand : ConsoleCommand
    {
        public override string Word => "Exit";
        public override string Description => "Stop playmode in editor";

        protected override string Invoke(List<string> arguments)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            return null;
        }
    }
}