using UnityEngine;

namespace Homework15
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private ItemSlot _itemSlot;

        public void Initialize()
        {
            //
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Use key pressed");
                _itemSlot.UseItem();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null && _itemSlot.IsEmpty)
            {
                //Debug.Log($"Item Triggered");
                _itemSlot.Add(triggeredItem);
            }
        }
    }
}