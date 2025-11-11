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

        public void Shoot(Transform firePoint)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, firePoint.rotation);
            bullet.transform.parent = null;
            bullet.Fly(_bulletSpeed);
        }
    }
}