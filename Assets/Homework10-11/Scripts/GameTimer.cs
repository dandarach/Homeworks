using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework11
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TimerUI _timerUI;

        private float _initialTime;

        public float Time { get; private set; }

        public bool IsReverse { get; private set; }

        public bool IsRunning { get; private set; }

        public void Initialize(float time = 0)
        {
            if (time == 0)
                IsReverse = true;

            Time = _initialTime = time;
            _timerUI.Initialize(Time);

            ResetTimer();
        }

        private void Update()
        {
            if (IsRunning)
            {
                if (IsReverse)
                    Time += UnityEngine.Time.deltaTime;
                else
                    Time -= UnityEngine.Time.deltaTime;

                _timerUI.UpdateTime(Time);
            }
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