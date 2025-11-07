using UnityEngine;
using Homework15.Characters;

namespace Homework15.Items
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private ItemSlot _itemSlot;
        private KeyCode _useItemKey;

        public void Initialize(KeyCode useItemKey)
        {
            _itemSlot = _character.GetComponent<ItemSlot>();
            _useItemKey = useItemKey;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_useItemKey))
                UseItem(_character);
        }

        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null)
                CollectItem(triggeredItem);
        }

        private void CollectItem(Item item)
        {
            if (_itemSlot.IsEmpty == false)
                return;
                
            _itemSlot.Push(item);
            item.Collect();

        }

        private void UseItem(Character character)
        {
            Item item = _itemSlot.Pop();
            _itemSlot.Clear();

            if (item == null)
                return;

            PlayParticleEffect(item);
            item.Use(character);
        }

        public void PlayParticleEffect(Item item)
        {
            ParticleSystem itemParticleEffectPrefab = item.GetItemEffectPrefab();

            if (itemParticleEffectPrefab == null)
                return;

            ParticleSystem itemParticleEffect = Instantiate(itemParticleEffectPrefab, item.transform, false);
            itemParticleEffect.transform.parent = null;
            itemParticleEffect.Play();
        }
    }
}