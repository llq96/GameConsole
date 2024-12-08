using System.Collections.Generic;

namespace GameConsole.Commands
{
    public abstract class SimpleCommand : BaseCommand
    {
        protected SimpleCommand() : base()
        {
        }

        protected override string Invoke(List<string> arguments)
        {
            return Invoke();
        }

        protected abstract string Invoke();
    }
}