using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemCoin : Item
    {
        public override void Use(Character character)
        {
            base.Use(character);

            Debug.Log($"* Coin used");
        }
    }
}