using System.Collections.Generic;

namespace GameConsole.Commands
{
    internal class InternalCommands
    {
        private readonly List<BaseCommand> _commands = new();

        public InternalCommands(Console console)
        {
            _commands.Add(new ClearCommand(console.ConsoleOutput));
            _commands.Add(new HelpCommand(console.ConsoleCommands));
            _commands.Add(new ExitCommand());
            _commands.Add(new TimeScaleCommand());
            _commands.Add(new SetCameraColorCommand());
        }

        public List<BaseCommand> GetCommands() => _commands;
    }
}