using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework11
{
    public class Game : MonoBehaviour
    {
        private const float DistanceToDie = 0.5f;
        private const KeyCode RestartKey = KeyCode.R;

        [SerializeField] private DistanceDetector _distanceDetector;
        [SerializeField] private Hero _hero;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _minDistanceBetweenCharacters;

        [SerializeField] private float _timeToWin;
        [SerializeField] private float _timeToDie;

        [SerializeField] private GameTimer _winTimer;
        [SerializeField] private GameTimer _dieTimer;

        private GameMessenger _gameMessenger;
        private bool _isRunning;

        private void Awake()
        {
            Debug.Log("--- AWAKE Game ---");
            Initialize();
        }

        private void Initialize()
        {
            _gameMessenger = gameObject.GetComponent<GameMessenger>();
            _gameMessenger.Initialize(RestartKey);
            _gameMessenger.PrintWelcomeMessage();

            _distanceDetector.Initialize(_minDistanceBetweenCharacters);

            _hero.Initialize();
            _enemy.Initialize();
            _enemy.Patrol();

            _winTimer.Initialize(_timeToWin);
            _dieTimer.Initialize(_timeToDie);
            StartFirstTimer();

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

            if (_distanceDetector.Distance <= DistanceToDie || _dieTimer.Time <= 0)
            {
                HeroDie();
                return;
            }
            else if (_winTimer.Time <= 0)
            {
                HeroWin();
                return;
            }

            if (_distanceDetector.IsDetectStateChanged)
            {
                SwapTimers();
                //ResetTimers();
                //StartFirstTimer();
            }
        }

        private void HeroDie()
        {
            _gameMessenger.PrintDieGameMessage();
            _gameMessenger.PrintRestartGameMessage();

            _isRunning = false;
            _enemy.Win();
            _hero.Kill();
            StopTimers();
        }

        private void HeroWin()
        {
            _gameMessenger.PrintWinGameMessage();
            _gameMessenger.PrintRestartGameMessage();

            _isRunning = false;
            _enemy.Kill();
            _hero.Win();
            StopTimers();
        }

        private void Restart()
        {
            _gameMessenger.PrintWelcomeMessage();

            _enemy.Reborn();
            _enemy.Patrol();
            _hero.Reborn();

            ResetTimers();
            StartFirstTimer();

            _isRunning = true;
        }

        private void StopTimers()
        {
            _winTimer.Pause();
            _dieTimer.Pause();
        }

        private void ResetTimers()
        {
            _winTimer.ResetTimer();
            _dieTimer.ResetTimer();
        }

        private void StartFirstTimer()
        {
            if (_distanceDetector.IsDetected())
                _winTimer.Play();
            else
                _dieTimer.Play();
        }

        private void SwapTimers()
        {
            if (_winTimer.IsRunning)
            {
                _winTimer.Pause();
                _dieTimer.Play();
            }
            else
            {
                _winTimer.Play();
                _dieTimer.Pause();
            }
        }
    }
}