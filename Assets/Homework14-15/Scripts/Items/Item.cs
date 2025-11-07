using UnityEngine;

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

        public bool IsUsed { get; private set; } = false;

        public void Initialize()
        {
            _itemEffects.Initialize();
            _time = _destroyTime;
        }

        private void Update()
        {
            if (IsCollected || IsUsed)
                return;

            _time -= Time.deltaTime;

            //if (_time <= 0)
                //Kill();
        }

        public void Collect()
        {
            Debug.Log($"+ Item collected");
            _itemEffects.FreezeEffects();
            _collectEffect.Play();
            IsCollected = true;
        }

        public virtual void Use()
        {
            Debug.Log("* Item used");
            _itemEffects.FreezeEffects();
            IsUsed = true;
            Kill();
        }

        public ParticleSystem GetItemEffectPrefab() => _useEffectPrefab;

        private void Kill()
        {
            IsUsed = true;
            Destroy(gameObject);
        }
    }
}