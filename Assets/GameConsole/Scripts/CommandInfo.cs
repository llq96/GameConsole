using System;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace GameConsole
{
    public class CommandInfo : MonoBehaviour
    {
        [Header("Console Components")]
        [SerializeField] private ConsoleCommands _consoleCommands;

        [Header("UI Components")]
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _commandInfo;
        [SerializeField] private TextMeshProUGUI _tmp_commandInfo;
        [SerializeField] private TextMeshProUGUI _tmp_commandDescription;

        [Header("Colors")]
        [SerializeField] private Color _color_commandWord;
        [SerializeField] private Color _color_commandParameter;


        private ConsoleCommand _currentCommand;

        private void Awake()
        {
            _inputField.onValueChanged.AddListener(UpdateInfo);

            UpdateInfo("");
        }

        private void UpdateInfo(string input)
        {
            _currentCommand = GetSuitableCommand(input);
            _commandInfo.SetActive(_currentCommand != null);
            if (_currentCommand != null)
            {
                _tmp_commandInfo.text = GetInfo(_currentCommand);
                _tmp_commandDescription.text = _currentCommand.Description;
            }
        }

        private ConsoleCommand GetSuitableCommand(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            if (input == "/") return null;
            var writtenLocation = _consoleCommands.Commands.FirstOrDefault(x => input.StartsWith($"/{x.Word}"));
            if (writtenLocation != null) return writtenLocation;
            var possibleCommand = _consoleCommands.Commands
                .FirstOrDefault(x => $"/{x.Word}".StartsWith(input, StringComparison.InvariantCultureIgnoreCase));
            return possibleCommand;
        }

        private string GetInfo(ConsoleCommand command)
        {
            StringBuilder sb = new();
            sb.Append($"/{command.Word}".WithColor(_color_commandWord));

            foreach (var parameter in command.Parameters)
            {
                sb.Append($" ({parameter})".WithColor(_color_commandParameter));
            }

            return sb.ToString();
        }
    }
}