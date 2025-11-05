using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostGame
{
    public class SpikesAnimator : MonoBehaviour
    {
        private const string OnTrigger = "On";
        private const string OffTrigger = "Off";

        [SerializeField] private List<Animator> _spikesAnimatorsTop;
        [SerializeField] private List<Animator> _spikesAnimatorsBottom;
        [SerializeField] private List<Animator> _spikesAnimatorsLeft;
        [SerializeField] private List<Animator> _spikesAnimatorsRight;

        public void Enable()
        {
            SetTriggers(_spikesAnimatorsTop, OnTrigger);
            SetTriggers(_spikesAnimatorsBottom, OnTrigger);
            SetTriggers(_spikesAnimatorsLeft, OnTrigger);
            SetTriggers(_spikesAnimatorsRight, OnTrigger);
        }

        public void Disable()
        {
            SetTriggers(_spikesAnimatorsTop, OffTrigger);
            SetTriggers(_spikesAnimatorsBottom, OffTrigger);
            SetTriggers(_spikesAnimatorsLeft, OffTrigger);
            SetTriggers(_spikesAnimatorsRight, OffTrigger);
        }

        private void SetTriggers(List<Animator> spikes, string trigger)
        {
            foreach (var spike in spikes)
                spike.SetTrigger(trigger);
        }
    }
}