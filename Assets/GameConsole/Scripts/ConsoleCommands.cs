using System.Collections.Generic;
using UnityEngine;

namespace GameConsole
{
    public class ConsoleCommands : MonoBehaviour
    {
        public List<ConsoleCommand> Commands { get; } = new();


        public void AddCommand(ConsoleCommand command) => Commands.Add(command);
        public void AddCommands(IEnumerable<ConsoleCommand> commands) => Commands.AddRange(commands);
    }
}