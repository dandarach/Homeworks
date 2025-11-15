using UnityEngine;

namespace Homework17.Characters
{
    public class CharacterMover
    {
        private readonly Color DebugRayColor = Color.yellow;

        private float _speed;
        private float _rotationSpeed;

        private GameObject _objectToMove;
        private Transform _initialTransform;

        public float Speed { get { return _speed; } }

        public void Initialize(GameObject objectToMove, float speed, float rotationSpeed)
        {
            Debug.Log("CharacterMover.Initialize");
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _initialTransform = objectToMove.transform;
            _objectToMove = objectToMove;
        }

        public void MoveTo(Vector3 direction)
        {
            _objectToMove.transform.Translate(_speed * Time.deltaTime * direction.normalized, Space.World);
            Debug.DrawRay(_objectToMove.transform.position, direction, DebugRayColor);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;

            _objectToMove.transform.rotation = Quaternion.RotateTowards(_objectToMove.transform.rotation, lookRotation, step);
        }

        public void MoveAndRotate(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
            _objectToMove.transform.position = _initialTransform.position;
            _objectToMove.transform.rotation = _initialTransform.rotation;
            _objectToMove.transform.localScale = _initialTransform.localScale;
        }
    }
}