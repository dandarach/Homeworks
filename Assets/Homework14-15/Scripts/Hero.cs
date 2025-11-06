using UnityEngine;

namespace Homework15
{
    public class Hero : MonoBehaviour
    {
        private const float DeadZone = 0.1f;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private CharacterAnimator _characterAnimator;

        private CharacterMover _characterMover;

        public bool IsAlive { get; private set; }

        public void Initialize()
        {
            _characterMover = new CharacterMover();
            _characterMover.Initialize(GetComponent<CharacterController>(), _speed, _rotationSpeed);
            IsAlive = true;
        }

        private void Awake()
        {
            Debug.Log("--- AWAKE Hero ---");
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