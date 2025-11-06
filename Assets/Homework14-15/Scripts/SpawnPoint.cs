using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class SpawnPoint : MonoBehaviour
    {
        private Item _item;

        public bool IsEmpty
        {
            get
            {
                if (_item == null || _item.gameObject == null)
                    return true;

                return false;
            }
        }

        public Vector3 Position => transform.position;

        public void Occupy (Item item)
        {
            _item = item;
        }
    }
}