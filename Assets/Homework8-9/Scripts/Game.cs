using UnityEngine;

namespace GhostGame
{
    public class Game : MonoBehaviour
    {
        private const KeyCode RestartKey = KeyCode.R;
        //private const KeyCode StartKey = KeyCode.Space;
        private const string CameraShakeKey = "Shake";

        [SerializeField] private string _welcomeMessage;
        [SerializeField] private string _looseMessage;
        [SerializeField] private string _winMessage;

        [SerializeField] private int _scoreToWin;
        [SerializeField] private Character _character;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private Boundary _boundary;
        [SerializeField] private Animator _cameraAnimator;
        [SerializeField] private GameEffects _gameEffects;

        private bool _isRunning;

        private void Awake()
        {
            Debug.Log("--- GAME.AWAKE ---");
            _isRunning = false;
            _character.SavePosition();
        }

        private void Initialize()
        {
            Debug.Log(_welcomeMessage);
            _boundary.Initialize();
            _character.Initialize();
            _gameEffects.EnableAll();
            _isRunning = true;
        }

        private void Update()
        {
            if ((Input.GetKeyDown(RestartKey) && _isRunning == false))
            {
                Initialize();
            }

            if (_isRunning == false)
                return;

            if (_boundary.IsOutOfBoundary(_character.transform.position))
                LooseGame();

            if (_scoreCounter.GetCurrentScores() >= _scoreToWin)
                WinGame();
        }

        private void LooseGame()
        {
            Debug.LogWarning(_looseMessage);
            PrintScores();
            _cameraAnimator.SetTrigger(CameraShakeKey);
            _character.Die();
            _gameEffects.DisableAll();
            _isRunning = false;
        }

        private void WinGame()
        {
            Debug.LogWarning(_winMessage);
            PrintScores();
            _character.Win();
            _gameEffects.DisableAll();
            _isRunning = false;
        }

        private void PrintScores()
        {
            Debug.Log($"Вы набрали {_scoreCounter.GetCurrentScores()} очков");
            Debug.Log($"Нажмите {RestartKey} для перезапуска игры");
        }
    }
}