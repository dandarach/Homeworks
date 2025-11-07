using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;
        [SerializeField] private ItemEffects _itemEffects;
        [SerializeField] private ParticleSystem _collectEffect;
        [SerializeField] private ParticleSystem _useEffectPrefab;

        private float _time;

        public bool IsCollected { get; private set; } = false;

        public void Initialize()
        {
            _itemEffects.Initialize();
            _time = _destroyTime;
        }

        private void Update()
        {
            if (IsCollected)
                return;

            _time -= Time.deltaTime;

            if (_time <= 0 && IsCollected == false)
                Kill();
        }

        public void Collect()
        {
            _itemEffects.FreezeEffects();
            _collectEffect.Play();
            IsCollected = true;
        }

        public virtual void Use(Character character)
        {
            _itemEffects.FreezeEffects();
            Kill();
        }

        public ParticleSystem GetItemEffectPrefab() => _useEffectPrefab;

        private void Kill()
        {
            Destroy(gameObject);
        }
    }
}