using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15.Items
{
    public class ItemBomb : Item
    {
        [Space]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletLifeTime;

        public override void Use()
        {
            base.Use();
            Debug.Log($"* Bomb used");

            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform.transform);
            bullet.transform.parent = null;
            bullet.Initialize(_bulletSpeed, _bulletLifeTime);
            bullet.Fly();
        }
    }
}