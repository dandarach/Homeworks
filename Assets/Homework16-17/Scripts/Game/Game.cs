using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Homework17.Characters;
using Homework17.Spawners;

namespace Homework17.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        
        private ItemSpawner _itemSpawner;

       private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _itemSpawner = new ItemSpawner();
            _itemSpawner.Initialize(_spawnPoints);
            _itemSpawner.SpawnAllItems();
        }
    }
}