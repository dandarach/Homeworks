using UnityEngine;

namespace Homework15
{
    public abstract class ObjectAnimator : MonoBehaviour
    {
        protected float _time;

        public bool IsAnimating { get; private set; } = true;

        public abstract void Initialize();

        protected virtual void Update()
        {
            if (IsAnimating == false)
                return;

            _time += Time.deltaTime;
            UpdateState();
        }

        public virtual void Freeze() => IsAnimating = false;
        
        public virtual void UnFreeze() => IsAnimating = true;

        protected abstract void UpdateState();
    }
}