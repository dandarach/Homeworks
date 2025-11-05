using UnityEngine;

namespace Homework13A
{
    public class GroundDetector : MonoBehaviour
    {
        public bool IsGroundDetected { get; private set; }

        private void OnCollisionEnter(Collision collision)
        {
            GroundBlock triggeredItem = collision.collider.GetComponent<GroundBlock>();
            if (triggeredItem != null)
            {
                Debug.Log("+ Ground detected");
                IsGroundDetected = true;
            }
            else
            {
                Debug.Log("- Ground lost");
                IsGroundDetected = false;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("- Ground lost");
            IsGroundDetected = false;
        }
    }
}