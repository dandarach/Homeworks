using UnityEngine;

namespace Homework15
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private Transform _itemSlotLocation;
        
        private ItemSlot _itemSlot;

        public void Initialize()
        {
            _itemSlot = new ItemSlot();
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
                triggeredItem.Collect();
                _itemSlot.Add(triggeredItem);
                triggeredItem.transform.SetParent(_itemSlotLocation, true);
            }
        }
    }
}