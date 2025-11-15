using UnityEngine;

namespace Homework17.Characters
{
    public class Mover
    {
        private float _speed;
        private float _rotationSpeed;

        private Transform _currentTransform;
        private Transform _initialTransform;

        public Color DebugRayColor { get; set; }

        public float Speed { get { return _speed; } }

        public void Initialize(Transform currentTransform, float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _initialTransform = _currentTransform = currentTransform;
            DebugRayColor = Color.red;
        }

        public void MoveTo(Vector3 direction)
        {
            _currentTransform.Translate(_speed * Time.deltaTime * direction.normalized, Space.World);
            Debug.DrawRay(_currentTransform.position, direction, DebugRayColor);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;
            _currentTransform.rotation = Quaternion.RotateTowards(_currentTransform.rotation, lookRotation, step);
        }

        public void MoveAndRotate(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
            _currentTransform.position = _initialTransform.position;
            _currentTransform.rotation = _initialTransform.rotation;
            _currentTransform.localScale = _initialTransform.localScale;
        }
    }
}