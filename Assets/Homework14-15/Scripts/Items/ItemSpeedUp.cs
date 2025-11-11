using UnityEngine;

namespace Homework15.Items
{
    public class ItemSpeedUp : Item
    {
        [Space]
        [SerializeField] private float _additionalSpeed;

        protected override void OnUse(GameObject gameObject)
        {
            Debug.Log($"* Bottle used");
            //character.SpeedUp(_additionalSpeed);
        }
    }
}