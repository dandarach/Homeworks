using UnityEngine;

namespace Homework15.Items
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;

        public void Fly(float speed)
        {
            Debug.Log("Bullet started");
            _speed = speed;
        }

        private void Update()
            => transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}