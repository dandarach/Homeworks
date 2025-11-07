using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework15.Items;

namespace Homework15.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<Item> _itemPrefabVariants;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        
        float _cooldown;
        private float _time;

        public void Initialize(float cooldown)
        {
            _time = 0;
            _cooldown = cooldown;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            
            if (_time >= _cooldown)
            {
                List<SpawnPoint> emptyPoints = GetEmptyPoints();

                if (emptyPoints.Count == 0 )
                {
                    _time = 0;
                    return;
                }

                Item itemPrefab = GetRandomPrefab();
                SpawnPoint spawnPoint = GetRandomPoint(emptyPoints);
                
                Item newItem = Instantiate(itemPrefab, spawnPoint.Position, Quaternion.identity);
                newItem.Initialize();

                spawnPoint.Occupy(newItem);
                _time = 0;
            }
        }

        private Item GetRandomPrefab()
            => _itemPrefabVariants[Random.Range(0, _itemPrefabVariants.Count)];

        private SpawnPoint GetRandomPoint(List<SpawnPoint> emptyPoints)
            => emptyPoints[Random.Range(0, emptyPoints.Count)];

        private List<SpawnPoint> GetEmptyPoints()
        {
            List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

            foreach (SpawnPoint point in _spawnPoints)
                if (point.IsEmpty)
                    emptyPoints.Add(point);

            return emptyPoints;
        }
    }
}