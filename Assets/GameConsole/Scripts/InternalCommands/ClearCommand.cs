using System.Collections.Generic;

namespace GameConsole
{
    internal class ClearCommand : ConsoleCommand
    {
        private readonly ConsoleOutput _consoleOutput;

        protected override string OverridedInput => string.Empty;

        public ClearCommand(ConsoleOutput consoleOutput) : base("Clear")
        {
            _consoleOutput = consoleOutput;
        }

        protected override string Invoke(List<string> arguments)
        {
            if (_consoleOutput != null)
            {
                _consoleOutput.ClearOutput();
            }

            return null;
        }
    }
}