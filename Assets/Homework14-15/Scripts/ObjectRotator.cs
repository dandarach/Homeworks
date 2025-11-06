using UnityEngine;

namespace Homework15
{
    public class ObjectRotator : MonoBehaviour
    {
        private const int ClockwiseRotateDirection = 1;
        private const int CounterClockwiseRotateDirection = -1;

        [SerializeField] private float _rotationSpeedMin;
        [SerializeField] private float _rotationSpeedMax;
        [SerializeField] private Vector3 _rotationAngle;
        
        [Space]
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _verticalAmplitude;

        private float _time;
        private float _phase;
        private float _rotationSpeed;
        private int _rotateDirection;
        private Vector3 _defaultPosition;

        public bool IsRotating { get; private set; } = true;

        public void StartRotate() => IsRotating = true;

        public void StopRotate() => IsRotating = false;

        public void InverseRotation() => _rotateDirection = -_rotateDirection;

        public void Awake()
        {
            _defaultPosition = transform.position;
            _rotationSpeed = GetRotationSpeed();
            _rotateDirection = GetRotateDirection();
            _phase = GetRandomPhase();
        }

        private void Update()
        {
            if (IsRotating == false)
                return;

            UpdatePositionAnsRotation(Time.deltaTime);
        }

        private int GetRotateDirection()
        {
            int chance = Random.Range(0, 2);
            return chance == 0 ? ClockwiseRotateDirection : CounterClockwiseRotateDirection;
        }

        private float GetRotationSpeed() => Random.Range(_rotationSpeedMin, _rotationSpeedMax + 1);
        
        private float GetRandomPhase() => Random.Range(0, Mathf.PI * 2);

        private void UpdatePositionAnsRotation(float deltaTime)
        {
            _time += deltaTime;

            transform.Rotate(_rotationAngle, _rotateDirection * _rotationSpeed * deltaTime);
            transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time * _verticalSpeed + _phase) * _verticalAmplitude;
        }
    }
}