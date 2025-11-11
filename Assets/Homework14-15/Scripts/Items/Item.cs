using UnityEngine;
using Homework15.Characters;
using Homework15.Utils;

namespace Homework15.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private ItemEffects _itemEffects;
        [SerializeField] private ParticleSystem _collectEffect;

        private float _time;
        private AutoDestroy _objectKiller;

        public bool IsCollected { get; private set; } = false;

        public void Initialize()
        {
            _itemEffects.Initialize();
            _objectKiller = GetComponent<AutoDestroy>();

            if (_objectKiller == null)
                Debug.LogError("Undable to get AutoDestroy Component");
        }

        public void Collect()
        {
            _itemEffects.FreezeEffects();
            _collectEffect.Play();
            _objectKiller.Off();
            IsCollected = true;
        }

        public void Use(Character character)
        {
            OnUse(character);
            _itemEffects.FreezeEffects();
            _objectKiller.Kill();
        }

        protected abstract void OnUse(Character character);
    }
}