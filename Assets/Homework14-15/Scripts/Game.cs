using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _hero;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private GameMessenger _gameMessenger;
        [SerializeField] private ItemSpawner _itemSpawner;

        private bool _isRunning;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _gameMessenger.Initialize(_gameSettings.RestartKey);
            _itemSpawner.Initialize(_gameSettings.ItemSpawnCooldown);
            _hero.Initialize(_gameSettings.CharacterSpeed, _gameSettings.CharacterRotationSpeed, _gameSettings.UseItemKey);

            _gameMessenger.PrintWelcomeMessage();
            _isRunning = true;
        }

        private void Update()
        {
            if ((Input.GetKeyDown(_gameSettings.RestartKey) && _isRunning == false))
            {
                Restart();
                return;
            }
            else if (_isRunning == false)
            {
                return;
            }
        }

        private void WinGame()
        {
            _gameMessenger.PrintDieGameMessage();
            _gameMessenger.PrintRestartGameMessage();

            _isRunning = false;
            _hero.Die();
        }

        private void LooseGame()
        {
            _gameMessenger.PrintWinGameMessage();
            _gameMessenger.PrintRestartGameMessage();

            _isRunning = false;
            _hero.Win();
        }

        private void Restart()
        {
            _gameMessenger.PrintWelcomeMessage();

            _hero.Reborn();
            _isRunning = true;
        }
    }
}