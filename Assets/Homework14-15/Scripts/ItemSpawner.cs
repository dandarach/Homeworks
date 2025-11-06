using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<Item> _itemVariants;
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public void Initialize(Item item, int numberOfItems)
        {
        }

        private Item GetRandomItemVariant(List<Item> itemVariants)
            => itemVariants[Random.Range(0, itemVariants.Count)];

        private SpawnPoint GetRandomSpawnPoint(List<SpawnPoint> spawnPoints)
            => _spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}