using UnityEngine;

namespace Homework17.Characters
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Transform _initialTransform;

        public Color DebugRayColor { get; set; }

        public void Awake()
        {
            _initialTransform = transform;
            DebugRayColor = Color.red;
        }

        public void MoveTo(Vector3 direction)
        {
            transform.Translate(_speed * Time.deltaTime * direction.normalized, Space.World);
            Debug.DrawRay(transform.position, direction, DebugRayColor);
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }

        public void MoveAndRotate(Vector3 direction)
        {
            RotateTo(direction);
            MoveTo(direction);
        }

        public void ResetTransform()
        {
            transform.position = _initialTransform.position;
            transform.rotation = _initialTransform.rotation;
            transform.localScale = _initialTransform.localScale;
        }
    }
}