using UnityEngine;

namespace Homework15.Utils
{
    public class ObjectKiller : MonoBehaviour
    {
        [SerializeField] private float _time;
        
        private bool _enabled;

        private void Awake()
        {
            _enabled = true;
        }

        public void Update()
        {
            if (_enabled == false)
                return;

            _time -= Time.deltaTime;

            if (_time <= 0)
                Kill();
        }

        public void Kill() => Destroy(gameObject);

        public void On() => _enabled = true;

        public void Off() => _enabled = false;
    }
}