using System.Collections.Generic;
using System.Text;

namespace GameConsole
{
    internal class HelpCommand : ConsoleCommand
    {
        private readonly ConsoleCommands _consoleCommands;

        public HelpCommand(ConsoleCommands consoleCommands) : base("Help")
        {
            _consoleCommands = consoleCommands;
        }

        protected override string Invoke(List<string> arguments)
        {
            if (_consoleCommands == null) return null;

            var sb = new StringBuilder();

            foreach (var command in _consoleCommands.Commands)
            {
                sb.Append($"/{command.Word} \n");
            }

            return sb.ToString();
        }
    }
}