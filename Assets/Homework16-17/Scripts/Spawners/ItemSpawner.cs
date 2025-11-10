using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework17.Interfaces;

namespace Homework17.Spawners
{
    public class ItemSpawner
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private List<ISpawnable> _itemPrefabs;

        public void Initialize(List<SpawnPoint> spawnPoints)
        {
            _spawnPoints = spawnPoints;
        }

        public void SpawnAllItems()
        {
            foreach (SpawnPoint item in _spawnPoints)
            {
                //SpawnItem(item);
            }
        }

        private void SpawnItem(ISpawnable item)
        {
           // item.Spawn();
        }
    }
}