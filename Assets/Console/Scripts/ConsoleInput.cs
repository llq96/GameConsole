using System;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ConsoleSystem
{
    public class ConsoleInput : MonoBehaviour
    {
        [Header("Console Components")]
        [SerializeField] private ConsoleCommands _consoleCommands;
        [SerializeField] private ConsoleCommandInvoker _consoleCommandInvoker;
        [SerializeField] private ConsoleHistory _consoleHistory;

        [Header("UI Components")]
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _tmp_commandHint;
        [SerializeField] private TextMeshProUGUI _tmp_input;
        [Space]
        [SerializeField] private Button _button_do;
        [SerializeField] private Image _buttonImage;

        [Header("Colors")]
        [SerializeField] private Color _tmpInputColor_correct;
        [SerializeField] private Color _tmpInputColor_wrong;
        [Space]
        [SerializeField] private Color _buttonImageColor_correct;
        [SerializeField] private Color _buttonImageColor_wrong;


        private ConsoleCommand _currentHintCommand;


        private void Awake()
        {
            _inputField.onEndEdit.AddListener(TryDoCommand);
            _inputField.onValueChanged.AddListener(UpdateHint);
            _inputField.onValueChanged.AddListener(UpdateUIAfterDelay);
            _button_do.onClick.AddListener(InvokeCommand);

            UpdateUIAfterDelay("");
        }

        private async void UpdateUIAfterDelay(string input)
        {
            try
            {
                await Task.Yield();
                await Task.Yield();
                var isCorrect = _consoleCommandInvoker.IsHaveMatchCommand(input);

                _buttonImage.color = isCorrect ? _buttonImageColor_correct : _buttonImageColor_wrong;
                _tmp_input.color = isCorrect ? _tmpInputColor_correct : _tmpInputColor_wrong;

                _button_do.interactable = !string.IsNullOrEmpty(input);
            }
            catch (Exception e)
            {
                // ignored
            }
        }


        private void UpdateHint(string input)
        {
            _currentHintCommand = GetCommandHint(input);
            if (_currentHintCommand != null)
            {
                _tmp_commandHint.gameObject.SetActive(true);
                _tmp_commandHint.text = $"/{_currentHintCommand.Word}";
            }
            else
            {
                _tmp_commandHint.gameObject.SetActive(false);
            }
        }

        private ConsoleCommand GetCommandHint(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            if (text == "/") return null;
            return _consoleCommands.Commands
                .FirstOrDefault(x => $"/{x.Word}".StartsWith(text, StringComparison.InvariantCultureIgnoreCase));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && _inputField.isFocused && _currentHintCommand != null)
            {
                _inputField.text = $"/{_currentHintCommand.Word}";
                _inputField.caretPosition = _inputField.text.Length;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && _inputField.isFocused)
            {
                if (_consoleHistory.TryGetPreviousCommand(out var input))
                {
                    _inputField.text = input;
                    _inputField.caretPosition = input.Length;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && _inputField.isFocused)
            {
                if (_consoleHistory.TryGetNextCommand(out var input))
                {
                    _inputField.text = input;
                    _inputField.caretPosition = input.Length;
                }
            }
        }

        private void TryDoCommand(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                InvokeCommand();
            }
        }

        private void InvokeCommand()
        {
            var input = _inputField.text;
            if (string.IsNullOrEmpty(input)) return;

            _inputField.text = "";
            _consoleCommandInvoker.InvokeCommand(input);
        }
    }
}