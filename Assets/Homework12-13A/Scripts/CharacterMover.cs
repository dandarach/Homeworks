using UnityEngine;

namespace Homework13A
{
    public class CharacterMover : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private const KeyCode JumpKey = KeyCode.Space;

        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _jumpForceVertical;
        [SerializeField] private float _jumpForceHorizontal;
        [SerializeField] private float _rotationForce;
        [SerializeField] private int _maxJumps;
        [SerializeField] private GroundDetector _groundDetector;

        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

        private float _xInput;
        private float _yInput;

        private int _jumpCounter;
        private bool _isJumpKeyPressed;

        private void Awake()
        {
            _initialPosition = transform.localPosition;
            _initialRotation = transform.localRotation;
        }

        public void Initialize()
        {
            ResetState();
        }

        private void Update()
        {
            _xInput = Input.GetAxis(HorizontalAxis);
            _yInput = Input.GetAxis(VerticalAxis);

            if (Input.GetKeyDown(JumpKey))
            {
                if (_groundDetector.IsGroundDetected)
                    _jumpCounter = _maxJumps;

                if (_jumpCounter > 0)
                {
                    _isJumpKeyPressed = true;
                    _jumpCounter--;
                }

                Debug.Log(_jumpCounter);
            }
        }

        private void FixedUpdate()
        {
            Move();

            if (_isJumpKeyPressed)
                Jump();
        }

        private void Move()
        {
            Vector3 direction = new Vector3(_yInput, 0, -_xInput);
            _rigidBody.AddTorque(direction * _rotationForce, ForceMode.Force);
        }

        private void Jump()
        {
            Vector3 jumpVector = new Vector3(_xInput * _jumpForceHorizontal, _jumpForceVertical, _yInput * _jumpForceHorizontal);
            _rigidBody.AddForce(jumpVector, ForceMode.Impulse);
            Debug.DrawRay(transform.position, jumpVector, Color.yellow);
            _isJumpKeyPressed = false;
        }

        public void ResetState()
        {
            _jumpCounter = _maxJumps;
            _rigidBody.isKinematic = true;

            transform.localPosition = _initialPosition;
            transform.localRotation = _initialRotation;

            _rigidBody.AddForce(Vector3.zero);
            _rigidBody.AddTorque(Vector3.zero);

            _rigidBody.isKinematic = false;
        }
    }
}