using UnityEngine;

namespace Homework15
{
    public class ObjectRotator : MonoBehaviour
    {
        private const int ClockwiseRotateDirection = 1;
        private const int CounterClockwiseRotateDirection = -1;

        [SerializeField] private float _rotationSpeedMin;
        [SerializeField] private float _rotationSpeedMax;

        private float _rotationSpeed;
        private int _rotateDirection;

        public bool IsRotating { get; private set; } = true;

        public void StartRotate() => IsRotating = true;

        public void StopRotate() => IsRotating = false;

        private void Awake()
        {
            _rotationSpeed = GetRotationSpeed();
            _rotateDirection = GetRotateDirection();
        }

        private void Update()
        {
            if (IsRotating == false)
                return;

            transform.Rotate(Vector3.up * _rotateDirection * _rotationSpeed * Time.deltaTime);
        }

        private int GetRotateDirection()
        {
            int chance = Random.Range(0, 2);
            return chance == 0 ? ClockwiseRotateDirection : CounterClockwiseRotateDirection;
        }

        private float GetRotationSpeed() => Random.Range(_rotationSpeedMin, _rotationSpeedMax);
    }
}