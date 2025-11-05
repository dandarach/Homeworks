using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework11
{
    public class GameMessenger : MonoBehaviour
    {
        [SerializeField] private Notificator _notificator;

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
            _notificator.SetTextColor(_welcomeGameMessageColor);
            _notificator.PrintText(_welcomeGameMessage);
        }

        public void PrintRestartGameMessage()
        {
            _notificator.AddText($" {_restartGameMessage} {_restartKey} key");
        }

        public void PrintWinGameMessage()
        {
            _notificator.SetTextColor(_winGameMessageColor);
            _notificator.PrintText(_winGameMessage);
        }

        public void PrintDieGameMessage()
        {
            _notificator.SetTextColor(_dieGameMessageColor);
            _notificator.PrintText(_dieGameMessage);
        }
    }
}