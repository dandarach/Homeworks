using UnityEngine;
using Homework15.Controllers;

namespace Homework15.Items
{
    public class ItemSpeedUp : Item
    {
        [Space]
        [SerializeField] private float _additionalSpeed;

        protected override void OnUse(GameObject gameObject)
        {
            Debug.Log($"* Bottle used");

            MoveController moveController = gameObject.GetComponent<MoveController>();

            if (moveController != null)
                moveController.SpeedUp(_additionalSpeed);
        }
    }
}