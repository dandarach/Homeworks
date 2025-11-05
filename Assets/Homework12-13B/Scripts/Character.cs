using UnityEngine;

namespace Homework13B
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _initialPosition;

        public void Awake()
        {
            _initialPosition = transform.position;
            _rigidbody.sleepThreshold = 0.0f;
            //_rigidbody.WakeUp();
        }

        public void ResetState()
        {
            Debug.Log("Character.ResetState");
            
            _rigidbody.isKinematic = true;

            transform.position = _initialPosition;

            _rigidbody.AddForce(Vector3.zero);
            _rigidbody.AddTorque(Vector3.zero);

            _rigidbody.isKinematic = false;
        }
    }
}