using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15.Items
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;
        private float _lifeTime;
        private float _time;
        private bool _isRunning;

        public void Initialize(float speed, float lifeTime)
        {
            _speed = speed;
            _lifeTime = lifeTime;
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

            transform.Translate(_speed * Time.deltaTime * Vector3.forward);

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