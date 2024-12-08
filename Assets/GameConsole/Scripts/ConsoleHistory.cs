using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameConsole
{
    public class ConsoleHistory : MonoBehaviour
    {
        private const string ConsoleHistoryPlayerPrefsKey = "ConsoleHistoryPlayerPrefsKey";

        [Header("Console Components")]
        [SerializeField] private ConsoleCommandInvoker _consoleCommandInvoker;

        private List<string> _history;

        private int? _lastHistoryIndex;

        private void Awake()
        {
            LoadHistoryFromPlayerPrefs();
            _consoleCommandInvoker.OnTryInvokeCommand += InvokeCommandHandler;
        }

        private void InvokeCommandHandler(string input)
        {
            var last = _history.LastOrDefault();
            if (last != null && last == input) return;

            _history.Add(input);
            _lastHistoryIndex = null;
            SaveHistoryToPlayerPrefs();
        }

        public bool TryGetPreviousCommand(out string input) => TryGetCommand(out input, -1);
        public bool TryGetNextCommand(out string input) => TryGetCommand(out input, 1);

        private bool TryGetCommand(out string input, int direction)
        {
            _lastHistoryIndex ??= _history.Count;

            if (_history.Count != 0)
            {
                _lastHistoryIndex += direction;
                _lastHistoryIndex = Mathf.Clamp(_lastHistoryIndex.Value, 0, _history.Count - 1);

                input = _history[_lastHistoryIndex.Value];
                return true;
            }

            input = null;
            return false;
        }

        #region Save/Load

        private void SaveHistoryToPlayerPrefs()
        {
            PlayerPrefs.SetString(ConsoleHistoryPlayerPrefsKey, string.Join("\n", _history));
        }

        private void LoadHistoryFromPlayerPrefs()
        {
            if (PlayerPrefs.HasKey(ConsoleHistoryPlayerPrefsKey))
            {
                var historyStr = PlayerPrefs.GetString(ConsoleHistoryPlayerPrefsKey);
                _history = historyStr.Split('\n').ToList();
            }
            else
            {
                _history = new List<string>();
            }
        }

        #endregion
    }
}