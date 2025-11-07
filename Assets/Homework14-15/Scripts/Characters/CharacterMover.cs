using UnityEngine;

namespace Homework15.Characters
{
    public class CharacterMover
    {
        private float _speed;
        private float _rotationSpeed;

        private CharacterController _characterController;
        private Vector3 _initialTransformPosition;
        private Quaternion _initialTransformRotation;
        private Vector3 _initialTransformScale;

        public void Initialize(CharacterController characterController, float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _characterController = characterController;

            _initialTransformPosition = _characterController.transform.position;
            _initialTransformRotation = _characterController.transform.rotation;
            _initialTransformScale = _characterController.transform.localScale;
        }

        public void MoveTo(Vector3 direction)
        {
            _characterController.Move(_speed * Time.deltaTime * direction.normalized);
            Debug.DrawRay(_characterController.transform.position, direction);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;

            _characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation, lookRotation, step);
        }

        public void RotateAndMoveTo(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
            _characterController.enabled = false;

            _characterController.transform.position = _initialTransformPosition;
            _characterController.transform.rotation = _initialTransformRotation;
            _characterController.transform.localScale = _initialTransformScale;

            _characterController.enabled = true;
        }
    }
}