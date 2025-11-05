using UnityEngine;

namespace Homework11
{
    public class DistanceDetector : MonoBehaviour
    {
        [SerializeField] private float _minDistanceForDetect;

        [SerializeField] private Transform _firstPoint;
        [SerializeField] private Transform _secondPoint;

        private bool _currentDetectState;
        private bool _lastDetectState;

        private Color _detectedLineColor = Color.green;
        private Color _undetectedLineColor = Color.red;

        public float Distance { get; private set; }

        public bool IsDetectStateChanged { get; private set; }

        public void Initialize(float minDistanceForDetect)
        {
            _minDistanceForDetect = minDistanceForDetect;
            IsDetectStateChanged = false;
            UpdateDistance();

            if (IsDetected())
                _currentDetectState = _lastDetectState = true;
            else
                _currentDetectState = _lastDetectState = false;
        }

        public bool IsDetected() => Distance <= _minDistanceForDetect;

        private void Update()
        {
            UpdateDistance();

            if (IsDetected())
            {
                Debug.DrawLine(_firstPoint.position, _secondPoint.position, _detectedLineColor);
                _currentDetectState = true;
            }
            else
            {
                Debug.DrawLine(_firstPoint.position, _secondPoint.position, _undetectedLineColor);
                _currentDetectState = false;
            }

            IsDetectStateChanged = (_currentDetectState != _lastDetectState) ? true : false;
            _lastDetectState = _currentDetectState;
        }

        private void UpdateDistance()
        {
            Distance = (_secondPoint.position - _firstPoint.position).magnitude;
        }
    }
}