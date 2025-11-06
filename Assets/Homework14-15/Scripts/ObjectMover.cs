using UnityEngine;

namespace Homework15
{
    public class ObjectMover : MonoBehaviour
    {
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _verticalAmplitude;

        private float _time;
        private float _phase;
        private Vector3 _defaultPosition;

        public bool IsMoving { get; private set; } = true;

        public void StartRotate() => IsMoving = true;

        public void StopRotate() => IsMoving = false;

        public void Awake()
        {
            _defaultPosition = transform.position;
            _phase = GetRandomPhase();
        }

        private void Update()
        {
            if (IsMoving == false)
                return;

            UpdatePositionAnsRotation(Time.deltaTime);
        }

        private float GetRandomPhase() => Random.Range(0, Mathf.PI * 2);

        private void UpdatePositionAnsRotation(float deltaTime)
        {
            _time += deltaTime;
            transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time * _verticalSpeed + _phase) * _verticalAmplitude;
        }
    }
}