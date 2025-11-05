using TMPro;
using UnityEngine;

namespace Homework13A
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerTextField;
        [SerializeField] private Color _textColor;

        [SerializeField] private TMP_Text _labelTextField;
        [SerializeField] private Color _labelColor;

        [SerializeField] private string _labelText;

        public void Initialize(float time)
        {
            _timerTextField.color = _textColor;
            _labelTextField.color = _labelColor;
            _labelTextField.text = _labelText;

            UpdateTime(time);
        }

        public void UpdateTime(float time)
        {
            _timerTextField.text = time.ToString("00.00");
        }
    }
}