using System.Collections.Generic;

namespace ConsoleSystem
{
    internal class InternalCommands
    {
        private readonly List<ConsoleCommand> _commands = new();

        public InternalCommands(Console console)
        {
            _commands.Add(new ClearCommand(console.ConsoleOutput));
            _commands.Add(new HelpCommand(console.ConsoleCommands));
            _commands.Add(new ExitCommand());
        }

        public List<ConsoleCommand> GetCommands() => _commands;
    }
}