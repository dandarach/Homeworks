using UnityEngine;

namespace Homework17
{
    public class DistanceDetector : MonoBehaviour
    {
        private Transform _firstPoint;
        private Transform _secondPoint;

        private float _minDistanceForDetect;

        private bool _currentDetectState;
        private bool _lastDetectState;

        private Color _detectedLineColor = Color.green;
        private Color _undetectedLineColor = Color.red;

        public float Distance { get; private set; }

        public bool IsDetectStateChanged { get; private set; }

        public void Initialize(Transform firstPoint, Transform secondPoint, float minDistanceForDetect)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
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

        public void SetDetectLineColors(Color detectedColor, Color undetectedColor)
        {
            _detectedLineColor = detectedColor;
            _undetectedLineColor = undetectedColor;
        }
    }
}