using UnityEngine;

namespace Homework13A
{
    public class CameraRotator : MonoBehaviour
    {
        private const string MouseXAxis = "Mouse X";
        private const string MouseYAxis = "Mouse Y";

        [SerializeField] private float _sensitivity;
        [SerializeField] private float _axisYLowLimit;
        [SerializeField] private float _axisYHighLimit;

        private float _aroundXrotation;
        private float _aroundYrotation;

        private void Awake()
        {
            _aroundXrotation = transform.eulerAngles.x;
            _aroundYrotation = transform.eulerAngles.y;
        }

        private void Update()
        {
            float mouseDeltaX = Input.GetAxis(MouseXAxis) * _sensitivity;
            float mouseDeltaY = Input.GetAxis(MouseYAxis) * _sensitivity;

            _aroundXrotation += mouseDeltaX;
            _aroundYrotation += mouseDeltaY;

            _aroundYrotation = Mathf.Clamp(_aroundYrotation, _axisYLowLimit, _axisYHighLimit);

            Quaternion rotation = Quaternion.Euler(-_aroundYrotation, _aroundXrotation, 0);

            transform.rotation = rotation;
        }
    }
}