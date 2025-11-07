using UnityEngine;

namespace Homework15
{
    public class ObjectMover : ObjectAnimator

    {
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _verticalAmplitude;

        private float _phase;
        private Vector3 _defaultPosition;

        public override void Initialize()
        {
            _defaultPosition = transform.position;
            _phase = GetRandomPhase();
        }

        private float GetRandomPhase() => Random.Range(0, Mathf.PI * 2);

        protected override void UpdateState()
        {
            transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time * _verticalSpeed + _phase) * _verticalAmplitude;
        }
    }
}