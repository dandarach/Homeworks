using UnityEngine;
using Homework15.Characters;
using Homework15.Spawners;

namespace Homework15.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _hero;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private ItemSpawner _itemSpawner;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _itemSpawner.Initialize(_gameSettings.ItemSpawnCooldown);
            _hero.Initialize(_gameSettings.UseItemKey);
        }
    }
}