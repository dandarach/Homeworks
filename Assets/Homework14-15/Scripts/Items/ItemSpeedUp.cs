using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemSpeedUp : Item
    {
        [Space]
        [SerializeField] private float _additionalSpeed;

        protected override void OnUse(Character character)
        {
            Debug.Log($"* Bottle used");
            character.SpeedUp(_additionalSpeed);
        }
    }
}