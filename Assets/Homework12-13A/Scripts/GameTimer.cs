using UnityEngine;

namespace Homework13A
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TimerUI _timerUI;

        private float _initialTime;
        private int _countDirection;

        public float Time { get; private set; }

        public bool IsReverse { get; private set; }

        public bool IsRunning { get; private set; }

        public void Initialize(float time = 0)
        {
            _countDirection = DetectCountDirection(time);
            Time = _initialTime = time;
            _timerUI.Initialize(Time);

            ResetTimer();
        }

        private int DetectCountDirection(float initialTime)
        {
            return (initialTime == 0) ? 1 : -1;

        }

        private void Update()
        {
            if (IsRunning == false)
                return;

            Time += UnityEngine.Time.deltaTime * _countDirection;
            _timerUI.UpdateTime(Time);
        }

        public void Play()
        {
            if (IsRunning)
                return;

            IsRunning = true;
        }

        public void Pause()
        {
            if (IsRunning == false)
                return;

            IsRunning = false;
        }

        public void ResetTimer()
        {
            IsRunning = false;
            Time = _initialTime;
            _timerUI.UpdateTime(Time);
        }
    }
}