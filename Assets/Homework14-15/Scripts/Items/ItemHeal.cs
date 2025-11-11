using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemHeal : Item
    {
        [Space]
        [SerializeField] private int _additionalHealth;

        protected override void OnUse(Character character)
        {
            Debug.Log($"* Coin used");
            character.Heal(_additionalHealth);
        }
    }
}