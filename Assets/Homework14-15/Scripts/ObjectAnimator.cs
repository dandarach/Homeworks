using UnityEngine;

namespace Homework15
{
    public abstract class ObjectAnimator : MonoBehaviour
    {
        protected float _time;

        public bool IsAnimating { get; private set; } = true;

        private Transform _initialTransform;

        public virtual void Initialize()
        {
            _initialTransform = gameObject.transform;
        }

        protected virtual void Update()
        {
            if (IsAnimating == false)
                return;

            _time += Time.deltaTime;
            UpdateState();
        }

        public virtual void Freeze()
        {
            IsAnimating = false;
            gameObject.transform.localPosition = _initialTransform.localPosition;
            gameObject.transform.rotation = Quaternion.identity;
        }
        
        public virtual void UnFreeze() => IsAnimating = true;

        protected abstract void UpdateState();
    }
}