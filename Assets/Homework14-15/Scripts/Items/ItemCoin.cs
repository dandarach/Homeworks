using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemCoin : Item
    {
        [Space]
        [SerializeField] private int _additionalHtalth;

        public override void Use(Character character)
        {
            base.Use(character);

            Debug.Log($"* Coin used");
            character.Heal(_additionalHtalth);
        }
    }
}