using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15.Items
{
    public class Shooter : MonoBehaviour
    {
        [Space]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletLifeTime;

        public void Shoot(Vector3 direction)
        {
            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.transform.parent = null;
            bullet.Initialize(_bulletSpeed, _bulletLifeTime, direction);
            bullet.Fly();
        }
    }
}