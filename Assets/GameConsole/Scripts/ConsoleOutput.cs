using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameConsole
{
    public class ConsoleOutput : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI _tmp_commands;
        [SerializeField] private VerticalLayoutGroup _commandsLayout;
        [SerializeField] private ScrollRect _scrollRect;

        [Header("Colors")]
        [SerializeField] private Color _color_correct_input;
        [SerializeField] private Color _color_correct_output;
        [SerializeField] private Color _color_error_input;
        [SerializeField] private Color _color_error_output;


        private void AddText(Color colorInput, Color colorOutput, string input, string output = null)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = input.WithColor(colorInput);
                _tmp_commands.text += input + '\n';
            }

            if (!string.IsNullOrEmpty(output))
            {
                output = output.WithColor(colorOutput);
                output = string.Join("\n", output.Split('\n').Select(s => $"   {s}"));
                _tmp_commands.text += $"{output}\n";
            }

            _ = GoToEndAsync();
        }


        public void AddNormalText(string text, string output)
        {
            AddText(_color_correct_input, _color_correct_output, text, output);
        }

        public void AddErrorText(string text, string output)
        {
            AddText(_color_error_input, _color_error_output, text, output);
        }

        private async Task GoToEndAsync()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_commandsLayout.GetComponent<RectTransform>());
            await Task.Yield();
            await Task.Yield();
            _scrollRect.normalizedPosition = Vector2.zero;
        }

        public void ClearOutput()
        {
            _tmp_commands.text = string.Empty;
            _ = GoToEndAsync();
        }
    }
}