using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Homework15
{
    public class ItemEffects : MonoBehaviour
    {
        [SerializeField] private List<ObjectAnimator> _objectAnimators;
        [SerializeField] private ParticleSystem _itemParticleEffectPrefab;

        public void Initialize()
        {
            InitializeEffects();
        }

        private void InitializeEffects()
        {
            foreach (ObjectAnimator animator in _objectAnimators)
                animator.Initialize();
        }

        public void FreezeEffects()
        {
            foreach (ObjectAnimator animator in _objectAnimators)
                animator.Freeze();
        }
        public void UnFreezeEffects()
        {
            foreach (ObjectAnimator animator in _objectAnimators)
                animator.UnFreeze();
        }

        public void PlayParticleEffect(Transform transform)
        {
            if (_itemParticleEffectPrefab == null)
                return;

            ParticleSystem itemParticleEffect = Instantiate(_itemParticleEffectPrefab, transform);
            itemParticleEffect.transform.parent = null;
            itemParticleEffect.Play();
        }
    }
}