using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostGame
{
    public class GameEffects : MonoBehaviour
    {
        private const string OnTrigger = "On";
        private const string OffTrigger = "Off";

        [SerializeField] private Animator _pumpkinAnimator;
        [SerializeField] private Animator _kosaAnimator;
        [SerializeField] private Boundary _boundary;
        [SerializeField] private ParticleSystem _mashroomSparkles;
        [SerializeField] private ParticleSystem _candleFire;
        [SerializeField] private ParticleSystem _candleSparkles;
        [SerializeField] private Torches _torches;

        private void Awake()
        {
            Debug.Log("--- GAME EFFECTS.AWAKE ---");
        }

        public void RotatePumpkin() => _pumpkinAnimator.SetTrigger(OnTrigger);

        public void StopRotatePumpkin() => _pumpkinAnimator.SetTrigger(OffTrigger);

        public void EnableSpikes() => _boundary.EnableEffect();

        public void DisableSpikes() => _boundary.DisableEffect();

        public void MoveKosa() => _kosaAnimator.SetTrigger(OnTrigger);

        public void StopMoveKosa() => _kosaAnimator.SetTrigger(OffTrigger);

        public void FireCandle()
        {
            _candleFire.Play();
            _candleSparkles.Play();
            _mashroomSparkles.Play();
        }

        public void PutOutCandle()
        {
            _candleFire.Stop();
            _candleFire.Clear();
            _candleSparkles.Stop();
            _mashroomSparkles.Stop();
        }

        public void EnableAll()
        {
            RotatePumpkin();
            MoveKosa();
            EnableSpikes();
            FireCandle();
            _torches.On();
        }

        public void DisableAll()
        {
            StopRotatePumpkin();
            StopMoveKosa();
            DisableSpikes();
            PutOutCandle();
            _torches.Off();
        }
    }
}