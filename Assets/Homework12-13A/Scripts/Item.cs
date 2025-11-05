using UnityEngine;

namespace Homework13A
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collectEffect;

        private int _score;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Collect()
        {
            if (_collectEffect == null)
                return;

            _collectEffect.transform.position = transform.position;
            _collectEffect.Play();
            Disable();
        }

        public void StopEffect() => _collectEffect.Stop();
    }
}