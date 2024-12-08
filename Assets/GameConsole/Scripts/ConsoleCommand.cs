using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GameConsole
{
    public abstract class ConsoleCommand
    {
        private readonly Regex _regex;
        public string Word { get; }

        protected ConsoleCommand(string word, int countParameters = 0)
        {
            Word = word;
            _regex = CreateRegex(word, countParameters);
        }

        private static Regex CreateRegex(string word, int countParameters = 0)
        {
            StringBuilder sb = new();
            sb.Append($"^/{word}");
            for (int i = 0; i < countParameters; i++)
            {
                sb.Append(" (\\w+)");
            }

            sb.Append("$");
            return new Regex(sb.ToString());
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

        public override string ToString() => _regex.ToString();
        protected virtual string OverridedInput => null;
    }
}