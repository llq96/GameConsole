namespace GameConsole.Commands
{
    internal class ClearCommand : SimpleCommand
    {
        private readonly ConsoleOutput _consoleOutput;

        public override string Word => "Clear";
        public override string Description => "Clear console output";

        protected override string OverridedInput => string.Empty;

        public ClearCommand(ConsoleOutput consoleOutput)
        {
            _consoleOutput = consoleOutput;
        }

        protected override string Invoke()
        {
            if (_consoleOutput != null)
            {
                _consoleOutput.ClearOutput();
            }

            return null;
        }
    }
}