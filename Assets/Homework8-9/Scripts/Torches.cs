using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostGame
{
    public class Torches : MonoBehaviour
    {
        private const string OnTrigger = "On";
        private const string OffTrigger = "Off";

        [SerializeField] private Animator _torchAnimator;
        [SerializeField] private ParticleSystem _torchFireLeft;
        [SerializeField] private ParticleSystem _torchFireRight;
        [SerializeField] private ParticleSystem _torchSparklesLeft;
        [SerializeField] private ParticleSystem _torchSparklesRight;

        public void On()
        {
            _torchFireLeft.Play();
            _torchFireRight.Play();
            _torchSparklesLeft.Play();
            _torchSparklesRight.Play();
            _torchAnimator.SetTrigger(OnTrigger);
        }

        public void Off()
        {
            _torchFireLeft.Stop();
            _torchFireRight.Stop();
            _torchFireLeft.Clear();
            _torchFireRight.Clear();
            _torchSparklesLeft.Stop();
            _torchSparklesRight.Stop();
            _torchAnimator.SetTrigger(OffTrigger);
        }
    }
}