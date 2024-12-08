using System;
using System.Linq;

namespace ConsoleSystem
{
    public class CommandInvokeResult
    {
        public Result Result { get; }
        public string Input { get; }
        public string Output { get; }

        private CommandInvokeResult(Result result, string input, string output)
        {
            Result = result;
            Input = input;
            Output = output;
        }


        public static CommandInvokeResult Success(string input, string output)
        {
            return new CommandInvokeResult(Result.Success, input, output);
        }

        public static CommandInvokeResult MatchError(string input, string output = "Wrong Parameters")
        {
            return new CommandInvokeResult(Result.MatchError, input, output);
        }

        public static CommandInvokeResult ExceptionError(string input, Exception exception)
        {
            var exceptionFirstLine = exception.ToString().Split('\n').FirstOrDefault();
            return new CommandInvokeResult(Result.ExceptionError, input, exceptionFirstLine);
        }
    }

    public enum Result
    {
        Success,
        MatchError,
        ExceptionError,
    }
}