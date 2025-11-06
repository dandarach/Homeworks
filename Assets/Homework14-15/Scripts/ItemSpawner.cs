using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<Item> _itemPrefabVariants;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] float _cooldown;

        private float _time;

        public void Initialize()
        {
            //
        }

        private void Update()
        {
            _time += Time.deltaTime;
            
            if (_time >= _cooldown)
            {
                Item itemPrefab = GetRandomItemPrefab();
                Transform spawnPoint = GetRandomSpawnPoint();
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
                Debug.Log($"Instantiate prefab {itemPrefab}");

                _time = 0;
            }
        }

        private Item GetRandomItemPrefab()
            => _itemPrefabVariants[Random.Range(0, _itemPrefabVariants.Count)];

        private Transform GetRandomSpawnPoint()
            => _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}