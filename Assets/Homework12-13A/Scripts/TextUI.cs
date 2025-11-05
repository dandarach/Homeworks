using TMPro;
using UnityEngine;

namespace Homework13A
{
    public class TextUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textField;

        public Color Color { get; private set; }

        public void PrintText(string text) => _textField.text = text;

        public void AddText(string text) => _textField.text += text;

        public void SetTextColor(Color color) => _textField.color = color;

        public void Clear() => _textField.text = "";
    }
}