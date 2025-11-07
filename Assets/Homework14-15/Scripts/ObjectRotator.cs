using UnityEngine;

namespace Homework15
{
    public class ObjectRotator : ObjectAnimator
    {
        private const int ClockwiseRotateDirection = 1;
        private const int CounterClockwiseRotateDirection = -1;

        [SerializeField] private float _rotationSpeedMin;
        [SerializeField] private float _rotationSpeedMax;
        [SerializeField] private Vector3 _rotationAngle;

        private float _rotationSpeed;
        private int _rotateDirection;

        public void InverseRotation() => _rotateDirection = -_rotateDirection;

        public override void Initialize()
        {
            _rotationSpeed = GetRotationSpeed();
            _rotateDirection = GetRotateDirection();
        }

        private int GetRotateDirection()
        {
            int chance = Random.Range(0, 2);
            return chance == 0 ? ClockwiseRotateDirection : CounterClockwiseRotateDirection;
        }

        private float GetRotationSpeed() => Random.Range(_rotationSpeedMin, _rotationSpeedMax + 1);
        
        protected override void UpdateState()
        {
            transform.Rotate(_rotationAngle, _rotateDirection * Time.deltaTime * _rotationSpeed);
        }
    }
}