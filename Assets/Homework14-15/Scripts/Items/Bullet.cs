using UnityEngine;

namespace Homework15.Items
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;
        private float _lifeTime;
        private float _time;
        private Vector3 _characterDirection;
        private bool _isRunning;

        public void Initialize(float speed, float lifeTime, Vector3 characterDirection)
        {
            _speed = speed;
            _lifeTime = lifeTime;
            _characterDirection = characterDirection;
            _isRunning = false;
        }

        public void Fly()
        {
            Debug.Log("Bullet started");
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _time += Time.deltaTime;

            transform.Translate(_speed * Time.deltaTime * _characterDirection);

            if (_time >= _lifeTime)
                Kill();
        }

        public void Kill()
        {
            Debug.Log("Bullet killed");
            Destroy(gameObject);
        }
    }
}