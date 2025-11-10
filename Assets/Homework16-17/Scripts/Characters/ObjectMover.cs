using UnityEngine;

namespace Homework17.Characters
{
    public class ObjectMover
    {
        private float _speed;
        private float _rotationSpeed;

        private GameObject _objectToMove;
        private Vector3 _initialTransformPosition;
        private Quaternion _initialTransformRotation;
        private Vector3 _initialTransformScale;


        public float Speed { get { return _speed; } }

        public virtual void Initialize(GameObject objectToMove, float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _objectToMove = objectToMove;
            
            _initialTransformPosition = _objectToMove.transform.position;
            _initialTransformRotation = _objectToMove.transform.rotation;
            _initialTransformScale = _objectToMove.transform.localScale;
        }

        public void MoveTo(Vector3 direction)
        {
            _objectToMove.transform.position += _speed * Time.deltaTime * direction.normalized;
            Debug.DrawRay(_objectToMove.transform.position, direction, Color.red);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;

            _objectToMove.transform.rotation = Quaternion.RotateTowards(_objectToMove.transform.rotation, lookRotation, step);
        }

        public virtual void Move(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
            _objectToMove.transform.position = _initialTransformPosition;
            _objectToMove.transform.rotation = _initialTransformRotation;
            _objectToMove.transform.localScale = _initialTransformScale;
        }
    }
}