using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework17.Interfaces;
using Homework17.Characters;

namespace Homework17.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public void Initialize()
        {
        }

        public void SpawnAllItems()
        {
            foreach(SpawnPoint spawnPoint in _spawnPoints)
            {
               SpawnItem(spawnPoint);
            }
        }

        public void SpawnItem(SpawnPoint spawnPoint)
        {
            Enemy newenemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}