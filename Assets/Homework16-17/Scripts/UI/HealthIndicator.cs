using UnityEngine;

namespace Homework17.UI
{
    public class HealthIndicator : MonoBehaviour
    {
        [SerializeField] private TextUI _healthUI;
        [SerializeField] private Color _healthTextColor;

        public void UpdateUI(int health)
            => _healthUI.PrintText(health.ToString("00"), _healthTextColor);
    }
}