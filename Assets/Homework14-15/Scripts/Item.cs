using UnityEngine;

namespace Homework15
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;
        [SerializeField] private ParticleSystem _collectEffect;

        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public void Initialize(int score = 0)
        {
            _score = score;

            //Destroy(gameObject, _destroyTime);
        }

        public void Collect()
        {
            if (_collectEffect == null)
                return;

            Debug.Log($"+ Item Collected");
            _collectEffect.transform.position = transform.position;
            _collectEffect.Play();
            //Destroy(gameObject);
        }
    }
}