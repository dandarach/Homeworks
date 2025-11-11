using UnityEngine;

namespace Homework15.Utils
{
    public class ObjectKiller : MonoBehaviour
    {
        [SerializeField] private float _time;
        
        public void Update()
        {
            _time -= Time.deltaTime;

            if (_time <= 0)
                Destroy(gameObject);
        }
    }
}