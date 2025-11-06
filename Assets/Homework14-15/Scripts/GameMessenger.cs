using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class GameMessenger : MonoBehaviour
    {
        [SerializeField] private TextUI _messengerUI;

        [SerializeField] private string _welcomeGameMessage;
        [SerializeField] private Color _welcomeGameMessageColor;
        [SerializeField] private string _dieGameMessage;
        [SerializeField] private Color _dieGameMessageColor;
        [SerializeField] private string _winGameMessage;
        [SerializeField] private Color _winGameMessageColor;
        [SerializeField] private string _restartGameMessage;

        private KeyCode _restartKey;

        public void Initialize(KeyCode restartKey) => _restartKey = restartKey;

        public void PrintWelcomeMessage()
        {
            _messengerUI.SetTextColor(_welcomeGameMessageColor);
            _messengerUI.PrintText(_welcomeGameMessage);
        }

        public void PrintRestartGameMessage()
        {
            _messengerUI.AddText($" {_restartGameMessage} {_restartKey}");
        }

        public void PrintWinGameMessage()
        {
            _messengerUI.SetTextColor(_winGameMessageColor);
            _messengerUI.PrintText(_winGameMessage);
        }

        public void PrintDieGameMessage()
        {
            _messengerUI.SetTextColor(_dieGameMessageColor);
            _messengerUI.PrintText(_dieGameMessage);
        }
    }
}