using UnityEngine;

namespace Homework17.Characters
{
    public class EnemyMover
    {
        private readonly Color DebugRayColor = Color.yellow;

        private float _speed;
        private float _rotationSpeed;

        private Transform _initialTransform;

        public float Speed { get { return _speed; } }

        public void Initialize(float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            //_initialTransform = characterController.transform;
        }

        public void MoveTo(Vector3 direction)
        {
            //_characterController.Move(_speed * Time.deltaTime * direction.normalized);
            //Debug.DrawRay(_characterController.transform.position, direction, DebugRayColor);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;

            //_characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation, lookRotation, step);
        }

        public void MoveAndRotate(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
           // _characterController.transform.position = _initialTransform.position;
           // _characterController.transform.rotation = _initialTransform.rotation;
           // _characterController.transform.localScale = _initialTransform.localScale;
        }
    }
}