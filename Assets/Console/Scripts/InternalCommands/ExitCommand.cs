﻿using System.Collections.Generic;

namespace ConsoleSystem
{
    internal class ExitCommand : ConsoleCommand
    {
        public ExitCommand() : base("Exit")
        {
        }

        protected override string Invoke(List<string> arguments)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            return null;
        }
    }
}