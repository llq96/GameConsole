using System;
using System.Linq;
using UnityEngine;

namespace GameConsole
{
    public class ConsoleCommandInvoker : MonoBehaviour
    {
        [Header("Console Components")]
        [SerializeField] private ConsoleCommands _consoleCommands;
        [SerializeField] private ConsoleOutput _consoleOutput;

        public event Action<string> OnTryInvokeCommand;

        public void InvokeCommand(string input)
        {
            OnTryInvokeCommand?.Invoke(input);

            var command = _consoleCommands.Commands.FirstOrDefault(x => x.IsMatch(input));

            if (command != null)
            {
                var invokeResult = command.Invoke(input);
                if (invokeResult.Result == Result.Success)
                {
                    _consoleOutput.AddNormalText(input, invokeResult.Output);
                }
                else
                {
                    _consoleOutput.AddErrorText(input, invokeResult.Output);
                }
            }
            else
            {
                _consoleOutput.AddErrorText(input, "Wrong Command");
            }
        }

        public bool IsHaveMatchCommand(string input)
        {
            return _consoleCommands.Commands.Any(x => x.IsMatch(input));
        }
    }
}