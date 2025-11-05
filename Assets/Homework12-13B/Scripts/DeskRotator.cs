using UnityEngine;

namespace Homework13B
{
    public class DeskRotator : MonoBehaviour
    {
        private const string XAxis = "Horizontal";
        private const string YAxis = "Vertical";

        [SerializeField] private float _sensitivity;
        [SerializeField] private Vector2 _axisXLimit;
        [SerializeField] private Vector2 _axisYLimit;

        private Vector2 _initialXYRotation;
        private Vector2 _aroundXYRotation;

        private void Awake()
        {
            _aroundXYRotation = _initialXYRotation = new Vector2(transform.eulerAngles.x, transform.eulerAngles.y);
        }
        
        private void Update()
        {
            _aroundXYRotation -= GetAxis();

            //_aroundXrotation = Mathf.Clamp(_aroundYrotation, _axisXLimit.x, _axisXLimit.y);
            //_aroundYrotation = Mathf.Clamp(_aroundYrotation, _axisYLimit.x, _axisYLimit.y);

            Rotate(_aroundXYRotation);
        }

        private Vector2 GetAxis()
        {
            return new Vector2(Input.GetAxis(XAxis), Input.GetAxis(YAxis)) * _sensitivity;
        }

        private void Rotate(Vector2 aroundXYRotation)
        {
            Quaternion rotation = Quaternion.Euler(-_aroundXYRotation.y, 0, _aroundXYRotation.x);
            transform.rotation = rotation;
        }

        public void ResetState()
        {
            Debug.Log("DeskRotator.ResetState");
            Rotate(_initialXYRotation);
        }
    }
}