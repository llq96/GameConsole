using System.Collections.Generic;
using GameConsole.Commands;
using UnityEngine;

namespace GameConsole
{
    public class Console : MonoBehaviour
    {
        [field: Header("Console Components")]
        [field: SerializeField] public ConsoleInput ConsoleInput { get; private set; }
        [field: SerializeField] public ConsoleOutput ConsoleOutput { get; private set; }
        [field: SerializeField] public ConsoleCommands ConsoleCommands { get; private set; }
        [field: SerializeField] public ConsoleCommandInvoker ConsoleCommandInvoker { get; private set; }
        [field: SerializeField] public ConsoleHistory ConsoleHistory { get; private set; }

        private InternalCommands _internalCommands;

        private void Awake()
        {
            _internalCommands = new InternalCommands(this);
            ConsoleCommands.AddCommands(_internalCommands.GetCommands());
        }

        public void AddCommand(BaseCommand command) => ConsoleCommands.AddCommand(command);
        public void AddCommands(IEnumerable<BaseCommand> commands) => ConsoleCommands.AddCommands(commands);
    }
}