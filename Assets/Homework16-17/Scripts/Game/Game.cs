using UnityEngine;
using Homework17.Characters;
//using Homework17.Spawners;

namespace Homework17.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _hero;
        //[SerializeField] private ItemSpawner _itemSpawner;

        private bool _isRunning;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _hero.Initialize(GameSettings.CharacterSpeed, GameSettings.CharacterRotationSpeed);
            //_itemSpawner.Initialize();

            _isRunning = true;
        }
    }
}