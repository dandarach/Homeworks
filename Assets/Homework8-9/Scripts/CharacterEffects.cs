using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostGame
{
    public class CharacterEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _jumpParticles;
        [SerializeField] private ParticleSystem _explosionBonesParticles;
        [SerializeField] private ParticleSystem _explosionParticles;
        [SerializeField] private ParticleSystem _winParticles;
        [SerializeField] private TrailRenderer _trail;


        public void ResetEffects()
        {
            _trail.Clear();
            _winParticles.Stop();
        }

        public void Explode()
        {
            _explosionBonesParticles.Play();
            _explosionParticles.Play();

        }

        public void PlayWinEffect() => _winParticles.Play();

        public void PlayJumpEffect() => _jumpParticles.Play();
    }
}