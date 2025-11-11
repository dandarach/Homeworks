using UnityEngine;

namespace Homework15.Items
{
    public class ItemShoot : Item
    {
        protected override void OnUse(GameObject gameObject)
        {
            Debug.Log($"* Bomb used");
            
            Shooter shooter = GetComponent<Shooter>();

            if (shooter != null)
                shooter.Shoot(gameObject.transform);
        }
    }
}