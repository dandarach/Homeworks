using UnityEngine;

namespace Homework15.Items
{
    public class ItemHeal : Item
    {
        [Space]
        [SerializeField] private int _additionalHealth;

        protected override void OnUse(GameObject gameObject)
        {
            Debug.Log($"* Coin used");
            //character.Heal(_additionalHealth);
        }
    }
}