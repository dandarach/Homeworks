using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework15.Game;

namespace Homework15.Items
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Transform _slotLocation;
        [SerializeField] private Vector3 _slotLocationCorrection;
        [SerializeField] private GameMessenger _gameMessenger;

        private Item _item;

        public bool IsEmpty { get; private set; } = true;

        public void Push(Item item)
        {
            if (IsEmpty == false)
            {
                Debug.LogWarning("Sorry. You can collect only one item!");
                return;
            }

            Debug.Log($"+ Item {item} added to Item Slot");

            item.transform.SetParent(_slotLocation, true);
            item.transform.localPosition = Vector3.zero + _slotLocationCorrection;

            _item = item;
            IsEmpty = false;
        }

        public Item Pop()
        {
            if (IsEmpty)
            {
                Debug.LogWarning("You have no items!");
                _gameMessenger.PrintEmptySlotMessage();
                
                return null;
            }

            _item.transform.parent = null;
            
            return _item;
        }

        public void Clear()
        {
            _item = null;
            IsEmpty = true;
        }
    }
}