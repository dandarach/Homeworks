using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework13A
{
    public class Game : MonoBehaviour
    {
        private const KeyCode RestartKey = KeyCode.R;

        [SerializeField] private Character _character;
        [SerializeField] private float _timeToDie;
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private GameMessenger _gameMessenger;

        private bool _isRunning;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _character.Initialize();
            _scoreCounter.Initialize();
            _gameTimer.Initialize(_timeToDie);
            _gameMessenger.Initialize();

            _gameTimer.Play();
            _isRunning = true;
        }

        private void Update()
        {
            if ((Input.GetKeyDown(RestartKey) && _isRunning == false))
            {
                Restart();
                return;
            }
            else if (_isRunning == false)
            {
                return;
            }

            if (_scoreCounter.IsAllItemsCollected)
                WinGame();

            if (_gameTimer.Time <= 0)
                LooseGame();
        }

        private void LooseGame()
        {
            Debug.LogWarning("*** Loose Game ***");

            _gameMessenger.PrintLooseGameMessage();
            _gameMessenger.PrintRestartGameMessage(RestartKey);

            _character.Kill();
            _gameTimer.Pause();
            _isRunning = false;
        }

        private void WinGame()
        {
            Debug.LogWarning("*** Win Game ***");

            _gameMessenger.PrintWinGameMessage();
            _gameMessenger.PrintRestartGameMessage(RestartKey);

            _character.Win();
            _gameTimer.Pause();
            _isRunning = false;
        }

        private void Restart()
        {
            Initialize();
        }
    }
}