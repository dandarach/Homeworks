using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemShoot : Item
    {
        public override void Use(Character character)
        {
            base.Use(character);
            Debug.Log($"* Bomb used");
            
            Shooter shooter = GetComponent<Shooter>();

            if ( shooter != null )
            {
                shooter.Shoot(character.transform.forward);
            }
        }
    }
}