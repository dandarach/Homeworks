using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class SpawnPoint : MonoBehaviour
    {
        private Item _item;

        public Transform Transform {  get; private set; }

        public void Initialize(List<Item> itemVariants)
        {
            _item = GetRandomItem(itemVariants);
            Transform = transform;
            Debug.Log($"SpawnPoint: {Transform}");
        }

        private Item GetRandomItem(List<Item> itemVariants)
            => itemVariants[Random.Range(0, itemVariants.Count)];
    }
}