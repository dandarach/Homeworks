using UnityEngine;

namespace Homework13A
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            Vector3 newOffset = transform.rotation * _offset;
            transform.position = _target.position + newOffset;
        }
    }
}