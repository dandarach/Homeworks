using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework15.Spawners;


namespace Homework17.Spawners
{
    public class ItemSpawner
    {
        private List<SpawnPoint> _spawnPoints;

        public void Initialize(List<SpawnPoint> spawnPoints)
        {
            _spawnPoints = spawnPoints;
        }

        public void SpawnAllItems()
        {
            foreach(SpawnPoint spawnPoint in _spawnPoints)
               SpawnItem(spawnPoint);
        }

        public void SpawnItem(SpawnPoint spawnPoint) => spawnPoint.Spawn();
    }
}