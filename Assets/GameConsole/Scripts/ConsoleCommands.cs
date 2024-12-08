using System.Collections.Generic;
using GameConsole.Commands;
using UnityEngine;

namespace GameConsole
{
    public class ConsoleCommands : MonoBehaviour
    {
        public List<BaseCommand> Commands { get; } = new();


        public void AddCommand(BaseCommand command) => Commands.Add(command);
        public void AddCommands(IEnumerable<BaseCommand> commands) => Commands.AddRange(commands);
    }
}