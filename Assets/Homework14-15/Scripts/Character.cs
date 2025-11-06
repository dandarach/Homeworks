using UnityEngine;

namespace Homework15
{
    public class Character : MonoBehaviour
    {
        private const float DeadZone = 0.1f;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        [SerializeField] private CharacterAnimator _characterAnimator;

        private CharacterMover _characterMover;

        public bool IsAlive { get; private set; }

        public void Initialize(float characterSpeed, float characterRotationSpeed)
        {
            _characterMover = new CharacterMover();

            CharacterController characterController = GetComponent<CharacterController>();

            if (characterController != null)
            {
                _characterMover.Initialize(characterController, characterSpeed, characterRotationSpeed);
                IsAlive = true;
            }
            else
            {
                Debug.LogError("Character. Unable to get CharacterController");
            }
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