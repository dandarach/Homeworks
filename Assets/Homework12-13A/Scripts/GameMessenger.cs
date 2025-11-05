using UnityEngine;

namespace Homework13A
{
    public class GameMessenger : MonoBehaviour
    {
        [SerializeField] private TextUI _textUI;

        [SerializeField] private string _welcomeGameMessage;
        [SerializeField] private Color _welcomeGameMessageColor;

        [SerializeField] private string _winGameMessage;
        [SerializeField] private Color _winGameMessageColor;

        [SerializeField] private string _looseGameMessage;
        [SerializeField] private Color _looseGameMessageColor;

        [SerializeField] private string _restartGameMessage;

        public void Initialize()
        {
            Clear();
        }

        public void PrintWelcomeGameMessage()
        {
            _textUI.SetTextColor(_welcomeGameMessageColor);
            _textUI.PrintText(_welcomeGameMessage);
        }

        public void PrintWinGameMessage()
        {
            _textUI.SetTextColor(_winGameMessageColor);
            _textUI.PrintText(_winGameMessage);
        }

        public void PrintLooseGameMessage()
        {
            _textUI.SetTextColor(_looseGameMessageColor);
            _textUI.PrintText(_looseGameMessage);
        }

        public void PrintRestartGameMessage(KeyCode restartKeyCode)
        {
            _textUI.AddText($"\n{_restartGameMessage} {restartKeyCode}");
        }

        public void Clear()
        {
            _textUI.Clear();
        }
    }
}