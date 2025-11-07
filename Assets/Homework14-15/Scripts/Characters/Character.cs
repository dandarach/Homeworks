using UnityEngine;
using Homework15.Items;
using Homework15.UI;

namespace Homework15.Characters
{
    public class Character : MonoBehaviour
    {
        private const float DeadZone = 0.1f;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private ItemsCollector _itemsCollector;
        [SerializeField] private HealthIndicator _healthIndicator;

        private CharacterMover _characterMover;
        
        public int Health { get; private set; }
        
        public bool IsAlive { get; private set; }

        public void Initialize(
            float characterInitialSpeed,
            float characterRotationSpeed,
            float characterMaximumSpeed,
            int initialHealth,
            KeyCode useItemKey)
        {
            _characterMover = new CharacterMover();
            _itemsCollector.Initialize(useItemKey);
            Health = initialHealth;

            CharacterController characterController = GetComponent<CharacterController>();

            if (characterController != null)
            {
                _characterMover.Initialize(characterController, characterInitialSpeed, characterMaximumSpeed, characterRotationSpeed);
                IsAlive = true;
            }
            else
            {
                Debug.LogError("Character. Unable to get CharacterController");
            }

            _healthIndicator.UpdateUI(Health);
        }

        private void Update()
        {
            if (IsAlive == false)
                return;

            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            if (input.magnitude <= DeadZone)
                return;

            _characterMover.RotateAndMoveTo(input);
        }

        public void Heal(int additionalHealth)
        {
            Health += additionalHealth;
            _healthIndicator.UpdateUI(Health);
            Debug.Log($"Heal: {additionalHealth}. Total Health: {Health}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            CheckHealth();
            _healthIndicator.UpdateUI(Health);
            Debug.Log($"Damage: {damage}. Total Health: {Health}");
        }

        private void CheckHealth()
        {
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        public void SpeedUp(float additionalSpeed)
        {
            _characterMover.Accelerate(additionalSpeed);
            Debug.Log($"SpeedUp: {additionalSpeed}. Total Speed: {_characterMover.Speed}");
        }

        public void Disable() => IsAlive = false;

        public void Enable() => IsAlive = true;

        public void Die()
        {
            _characterAnimator.PlayDieAnimation();
            Disable();
        }

        public void Win()
        {
            _characterAnimator.PlayWinAnimation();
            Disable();
        }

        public void Reborn()
        {
            _characterMover.ResetTransform();
            _characterAnimator.Restart();
            Enable();
        }
    }
}