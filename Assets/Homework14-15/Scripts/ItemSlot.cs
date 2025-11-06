using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemSlot
    {
        private Item _item;

        public bool IsEmpty { get; private set; } = true;

        public void Add(Item item)
        {
            Debug.Log($"+ Item {item} added to Item Slot");
            _item = item;
            IsEmpty = false;
        }

        public void UseItem()
        {
            if (IsEmpty)
                return;

            Debug.Log($"* Used Item {_item}");
            //_item.Use();
            _item = null;
            IsEmpty = true;
        }

        public Item GetItem() => _item;
    }
}