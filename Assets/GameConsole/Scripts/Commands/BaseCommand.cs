using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GameConsole.Commands
{
    public abstract class BaseCommand
    {
        public abstract string Word { get; }
        public string[] Arguments { get; }
        public virtual string Description => "";

        private readonly Regex _regex;

        internal BaseCommand(params string[] arguments)
        {
            Arguments = arguments;

            _regex = CreateRegex(Word, arguments.Length);
        }

        private static Regex CreateRegex(string word, int countArguments = 0)
        {
            StringBuilder sb = new();
            sb.Append($"^/{word}");
            for (int i = 0; i < countArguments; i++)
            {
                sb.Append(" (\\S+)");
            }

            sb.Append("$");
            return new Regex(sb.ToString(), RegexOptions.IgnoreCase);
        }

        public bool IsMatch(string input) => _regex.Match(input).Success;

        public CommandInvokeResult Invoke(string input)
        {
            var match = _regex.Match(input);
            var resultInput = OverridedInput ?? input;

            if (!match.Success) return CommandInvokeResult.MatchError(resultInput);

            try
            {
                var arguments = match.Groups.Skip(1).Select(x => x.Value).ToList();
                var output = Invoke(arguments);
                return CommandInvokeResult.Success(resultInput, output);
            }
            catch (Exception e)
            {
                return CommandInvokeResult.ExceptionError(resultInput, e);
            }
        }

        protected abstract string Invoke(List<string> arguments);

        protected virtual string OverridedInput => null;
    }
}