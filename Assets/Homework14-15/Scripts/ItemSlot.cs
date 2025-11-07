using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Transform _itemSlotLocation;
        [SerializeField] private GameMessenger _gameMessenger;

        private Item _item;

        public bool IsEmpty { get; private set; } = true;

        public void Add(Item item)
        {
            Debug.Log($"+ Item {item} added to Item Slot");
            item.transform.SetParent(_itemSlotLocation, true);
            item.Collect();

            _item = item;
            IsEmpty = false;
        }

        public void UseItem()
        {
            if (IsEmpty)
            {
                _gameMessenger.PrintEmptySlotMessage();
                return;
            }

            Debug.Log($"* Used Item {_item}");
            
            _item.Use();
            _item.transform.parent = null;
            _item = null;
            IsEmpty = true;
        }

        public Item GetItem() => _item;
    }
}