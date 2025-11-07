using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homework15.Effects;

namespace Homework15.Items
{
    public class ItemEffects : MonoBehaviour
    {
        [SerializeField] private List<ObjectAnimator> _objectAnimators;

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
    }
}