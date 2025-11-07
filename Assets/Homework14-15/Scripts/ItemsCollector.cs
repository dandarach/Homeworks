using Unity.VisualScripting;
using UnityEngine;

namespace Homework15
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private ItemSlot _itemSlot;

        private KeyCode _useItemKey = KeyCode.F;

        public void Initialize(KeyCode useItemKey)
        {
            _useItemKey = useItemKey;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_useItemKey))
                UseItem();
        }

        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null)
                CollectItem(triggeredItem);
        }

        private void CollectItem(Item item)
        {
            Debug.Log("CollectItem()");

            if (_itemSlot.IsEmpty == false)
                return;
                
            _itemSlot.Push(item);
            item.Collect();

        }

        private void UseItem()
        {
            Debug.Log("UseItem()");

            Item item = _itemSlot.Pop();

            if (item == null)
                return;

            Debug.Log($"* Used Item {item}");
            item.Use();
        }
    }
}