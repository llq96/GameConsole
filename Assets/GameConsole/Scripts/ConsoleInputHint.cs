using System;
using System.Linq;
using GameConsole.Commands;
using TMPro;
using UnityEngine;

namespace GameConsole
{
    public class ConsoleInputHint : MonoBehaviour
    {
        [Header("Console Components")]
        [SerializeField] private ConsoleCommands _consoleCommands;

        [Header("UI Components")]
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _tmp_commandHint;

        private BaseCommand _currentHintCommand;

        private void Awake()
        {
            _inputField.onValueChanged.AddListener(UpdateHints);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && _inputField.isFocused && _currentHintCommand != null)
            {
                _inputField.text = $"/{_currentHintCommand.Word}";
                _inputField.caretPosition = _inputField.text.Length;
            }
        }

        private void UpdateHints(string input)
        {
            _currentHintCommand = GetCommandHint(input);
            UpdateHint(input);
        }

        private void UpdateHint(string input)
        {
            _tmp_commandHint.gameObject.SetActive(_currentHintCommand != null);
            if (_currentHintCommand != null)
            {
                var hintText = $"/{_currentHintCommand.Word}".Substring(input.Length);
                _tmp_commandHint.text = input + hintText;
            }
        }

        private BaseCommand GetCommandHint(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            if (input == "/") return null;
            return _consoleCommands.Commands
                .FirstOrDefault(x => $"/{x.Word}".StartsWith(input, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}