namespace GameConsole.Commands
{
    internal class ExitCommand : SimpleCommand
    {
        public override string Word => "Exit";
        public override string Description => "Stop playmode in editor";

        protected override string Invoke()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            return null;
        }
    }
}