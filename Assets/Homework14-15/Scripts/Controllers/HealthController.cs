using UnityEngine;
using Homework15.UI;

namespace Homework15.Controllers
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _initialHealth;
        [SerializeField] private HealthIndicator _healthIndicator;

        public int Health { get; private set; }

        public void Initialize()
        {
            Health = _initialHealth;
            _healthIndicator.UpdateUI(Health);
        }

        public void IncreaseHealth(int additionalHealth)
        {
            Health += additionalHealth;
            _healthIndicator.UpdateUI(Health);
            Debug.Log($"Heal: {additionalHealth}. Total Health: {Health}");
        }

        public void DecreaseHealth(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            _healthIndicator.UpdateUI(Health);
            Debug.Log($"Damage: {damage}. Total Health: {Health}");
        }
    }
}