using UnityEngine;

namespace Homework15
{
    public class GameMessenger : MonoBehaviour
    {
        [SerializeField] private TextUI _messengerUI;
        [SerializeField] private float _timeToHideText;

        [SerializeField] private string _welcomeGameMessage;
        [SerializeField] private Color _welcomeGameMessageColor;

        [SerializeField] private string _dieGameMessage;
        [SerializeField] private Color _dieGameMessageColor;
        
        [SerializeField] private string _winGameMessage;
        [SerializeField] private Color _winGameMessageColor;
        
        [SerializeField] private string _emptySlotMessage;
        [SerializeField] private Color _emptySlotMessageColor;
        
        [SerializeField] private string _restartGameMessage;

        private KeyCode _restartKey;
        
        public void Initialize(KeyCode restartKey) => _restartKey = restartKey;

        public void PrintWelcomeMessage()
            => _messengerUI.PrintText(_welcomeGameMessage, _welcomeGameMessageColor, _timeToHideText);

        public void PrintRestartGameMessage()
            => _messengerUI.AddText($"\n{_restartGameMessage} {_restartKey}");

        public void PrintWinGameMessage()
            => _messengerUI.PrintText(_winGameMessage, _winGameMessageColor);

        public void PrintDieGameMessage()
            => _messengerUI.PrintText(_dieGameMessage, _dieGameMessageColor);

        public void PrintEmptySlotMessage()
            => _messengerUI.PrintText(_emptySlotMessage, _emptySlotMessageColor, _timeToHideText);
    }
}