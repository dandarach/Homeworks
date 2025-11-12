using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework17.Interfaces;
using Homework17.Characters;

namespace Homework17.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public void SpawnAllItems()
        {
            foreach(SpawnPoint spawnPoint in _spawnPoints)
               SpawnItem(spawnPoint);
        }

        public void SpawnItem(SpawnPoint spawnPoint) => spawnPoint.Spawn();
    }
}