using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Homework15.Items
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private ItemSlot _itemSlot;

        private KeyCode _useItemKey;

        public void Initialize(KeyCode useItemKey)
        {
            _useItemKey = useItemKey;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_useItemKey))
                UseItem();
        }

        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null)
                CollectItem(triggeredItem);
        }

        private void CollectItem(Item item)
        {
            Debug.Log("CollectItem()");

            if (_itemSlot.IsEmpty == false)
                return;
                
            _itemSlot.Push(item);
            item.Collect();

        }

        private void UseItem()
        {
            Item item = _itemSlot.Pop();
            _itemSlot.Clear();

            if (item == null)
                return;

            PlayParticleEffect(item);
            item.Use();
        }

        public void PlayParticleEffect(Item item)
        {
            ParticleSystem itemParticleEffectPrefab = item.GetItemEffectPrefab();

            if (itemParticleEffectPrefab == null)
                return;

            Debug.LogWarning("Play particle effect");

            ParticleSystem itemParticleEffect = Instantiate(itemParticleEffectPrefab, item.transform, false);
            itemParticleEffect.transform.parent = null;
            //itemParticleEffect.transform.position = Vector3.zero + new Vector3(0, 2, 0);
            Debug.Log(item.transform.position);
            itemParticleEffect.Play();
        }
    }
}