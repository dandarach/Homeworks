using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemBomb : Item
    {
        [Space]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletLifeTime;

        public override void Use(Character character)
        {
            base.Use(character);
            Debug.Log($"* Bomb used");
            
            Vector3 characterDirection = character.transform.forward;

            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.transform.parent = null;
            bullet.Initialize(_bulletSpeed, _bulletLifeTime, characterDirection);
            bullet.Fly();
        }
    }
}