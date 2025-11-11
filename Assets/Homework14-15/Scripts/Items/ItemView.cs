using UnityEngine;

namespace Homework15.Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private ItemEffects _itemEffects;
        [SerializeField] private ParticleSystem _collectEffect;

        public void Initialize()
        {
            _itemEffects.Initialize();
        }

        public void PlayCollectEffect()
        {
            _itemEffects.FreezeEffects();
            _collectEffect.Play();
        }

        public void PlayUseEffect()
        {
            _itemEffects.FreezeEffects();
        }
    }
}