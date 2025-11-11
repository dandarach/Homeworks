using UnityEngine;
using Homework15.Characters;
using Homework15.Utils;

namespace Homework15.Items
{
    public abstract class Item : MonoBehaviour
    {
        private ItemView _itemView;
        private AutoDestroy _objectKiller;

        public bool IsCollected { get; private set; } = false;

        public void Initialize()
        {
            _objectKiller = GetComponent<AutoDestroy>();

            if (_objectKiller == null)
                Debug.LogError("Undable to get AutoDestroy Component");

            _itemView = GetComponent<ItemView>();

            if (_itemView == null)
                Debug.LogError("Undable to get ItemView Component");
            else
                _itemView.Initialize();
        }

        public void Collect()
        {
            _itemView.PlayCollectEffect();
            _objectKiller.Off();
            IsCollected = true;
        }

        public void Use(Character character)
        {
            OnUse(character);
            _itemView.PlayUseEffect();
            _objectKiller.Kill();
        }

        protected abstract void OnUse(Character character);
    }
}