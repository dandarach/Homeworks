using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemShoot : Item
    {
        protected override void OnUse(Character character)
        {
            Debug.Log($"* Bomb used");
            
            Shooter shooter = GetComponent<Shooter>();

            if ( shooter != null )
            {
                //shooter.Shoot(shootDirection);
                shooter.Shoot(character.transform);
            }
        }
    }
}