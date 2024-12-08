using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace GameConsole.Commands
{
    public abstract class GenericCommand : BaseCommand
    {
        protected GenericCommand(params string[] arguments) : base(arguments)
        {
        }

        protected sealed override string Invoke(List<string> arguments)
        {
            var method = GetType().GetMethod("GenericInvoke", BindingFlags.Instance | BindingFlags.NonPublic);
            return method.Invoke(this, ParseArguments(arguments)) as string;
        }

        protected abstract object[] ParseArguments(List<string> arguments);
    }

    #region Generated

    public abstract class GenericCommand_1<TArgument0> : GenericCommand
    {
        protected GenericCommand_1(string argument0) : base(argument0)
        {
        }

        protected override object[] ParseArguments(List<string> arguments)
        {
            var argument0 = ArgumentParser.Parse<TArgument0>(arguments[0]);

            return new[] { argument0 };
        }

        [UsedImplicitly] protected abstract string GenericInvoke(TArgument0 argument);
    }

    public abstract class GenericCommand_2<TArgument0, TArgument1> : GenericCommand
    {
        protected GenericCommand_2(string argument0, string argument1) : base(argument0, argument1)
        {
        }

        protected override object[] ParseArguments(List<string> arguments)
        {
            var argument0 = ArgumentParser.Parse<TArgument0>(arguments[0]);
            var argument1 = ArgumentParser.Parse<TArgument1>(arguments[1]);

            return new[] { argument0, argument1 };
        }

        [UsedImplicitly] protected abstract string GenericInvoke(TArgument0 argument0, TArgument1 argument1);
    }

    public abstract class GenericCommand_3<TArgument0, TArgument1, TArgument2> : GenericCommand
    {
        protected GenericCommand_3(string argument0, string argument1, string argument2) : base(argument0,
            argument1, argument2)
        {
        }

        protected override object[] ParseArguments(List<string> arguments)
        {
            var argument0 = ArgumentParser.Parse<TArgument0>(arguments[0]);
            var argument1 = ArgumentParser.Parse<TArgument1>(arguments[1]);
            var argument2 = ArgumentParser.Parse<TArgument2>(arguments[2]);

            return new[] { argument0, argument1, argument2 };
        }

        [UsedImplicitly]
        protected abstract string GenericInvoke(TArgument0 argument0, TArgument1 argument1, TArgument2 argument2);
    }

    public abstract class
        GenericCommand_4<TArgument0, TArgument1, TArgument2, TArgument3> : GenericCommand
    {
        protected GenericCommand_4(string argument0, string argument1, string argument2, string argument3) :
            base(argument0, argument1, argument2, argument3)
        {
        }

        protected override object[] ParseArguments(List<string> arguments)
        {
            var argument0 = ArgumentParser.Parse<TArgument0>(arguments[0]);
            var argument1 = ArgumentParser.Parse<TArgument1>(arguments[1]);
            var argument2 = ArgumentParser.Parse<TArgument2>(arguments[2]);
            var argument3 = ArgumentParser.Parse<TArgument3>(arguments[3]);

            return new[] { argument0, argument1, argument2, argument3 };
        }

        [UsedImplicitly] protected abstract string GenericInvoke(TArgument0 argument0, TArgument1 argument1,
            TArgument2 argument2, TArgument3 argument3);
    }

    #endregion
}