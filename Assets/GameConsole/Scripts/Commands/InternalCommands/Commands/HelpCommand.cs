using System.Text;

namespace GameConsole.Commands
{
    internal class HelpCommand : SimpleCommand
    {
        private readonly ConsoleCommands _consoleCommands;

        public override string Word => "Help";
        public override string Description => "Show commands list";

        public HelpCommand(ConsoleCommands consoleCommands)
        {
            _consoleCommands = consoleCommands;
        }

        protected override string Invoke()
        {
            if (_consoleCommands == null) return null;

            var sb = new StringBuilder();


            for (var index = 0; index < _consoleCommands.Commands.Count; index++)
            {
                var command = _consoleCommands.Commands[index];
                sb.Append($"/{command.Word}");
                bool isLast = index == _consoleCommands.Commands.Count - 1;
                if (!isLast) sb.Append("\n");
            }


            return sb.ToString();
        }
    }
}