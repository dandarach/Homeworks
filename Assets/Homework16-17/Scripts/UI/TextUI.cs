using TMPro;
using UnityEngine;

namespace Homework17.UI
{
    public class TextUI : MonoBehaviour
    {

        [SerializeField] private TMP_Text _textField;

        private Color _defaultColor = Color.white;
        private bool _needToHideText = false;
        private float _timeToHideText;

        public Color Color { get; private set; }

        public void PrintText(string text, Color color, float timeToDisappear = 0)
        {
            if (color != null)
                SetTextColor(color);
            else
                SetTextColor(_defaultColor);

                _textField.text = text;

            if (timeToDisappear > 0)
            {
                _timeToHideText = timeToDisappear;
                _needToHideText = true;
            }
        }

        public void AddText(string text) => _textField.text += text;

        public void SetTextColor(Color color) => _textField.color = color;

        public void Clear() => _textField.text = "";

        private void Update()
        {
            if (_needToHideText == false)
                return;

            _timeToHideText -= Time.deltaTime;

            if (_timeToHideText <= 0)
            {
                _timeToHideText = 0;
                _needToHideText = false;
                
                Clear();
            }
        }
    }
}