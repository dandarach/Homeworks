using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework17.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        //[SerializeField] private List<Item> _itemPrefabVariants;

        public void Initialize(List<SpawnPoint> _spawnPoints)
        {
            for (int i  = 0; i < _spawnPoints.Count; i++)
            {

            }

            //Item newItem = Instantiate(itemPrefab, spawnPoint.Position, Quaternion.identity);
            //newItem.Initialize();
        }

        //private void CreateItem()
    }
}