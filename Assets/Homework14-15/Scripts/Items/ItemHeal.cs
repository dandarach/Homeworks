using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemHeal : Item
    {
        [Space]
        [SerializeField] private int _additionalHealth;

        public override void Use(Character character)
        {
            base.Use(character);

            Debug.Log($"* Coin used");
            character.Heal(_additionalHealth);
        }
    }
}