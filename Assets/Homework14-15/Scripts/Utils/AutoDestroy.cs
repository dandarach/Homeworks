using UnityEngine;

namespace Homework15.Utils
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private float _time;
        [SerializeField] private ParticleSystem _killEffectPrefab;
        
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

        public void Kill()
        {
            ParticleSystem killEffect = Instantiate(_killEffectPrefab, transform, false);

            if (_killEffectPrefab != null)
            {
                killEffect.transform.parent = null;
                killEffect.Play();
            }

            Destroy(gameObject);
        }

        public void On() => _enabled = true;

        public void Off() => _enabled = false;
    }
}