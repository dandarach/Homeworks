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
                _itemSlot.UseItem();
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