using Homework15.Controllers;
using Homework15.Items;
using Homework15.UI;
using UnityEngine;

namespace Homework15.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private ItemsCollector _itemsCollector;
        [SerializeField] private MoveController _moveController;
        [SerializeField] private HealthController _healthController;

        public void Initialize(KeyCode useItemKey)
        {
            _itemsCollector.Initialize(useItemKey);
            _moveController.Initialize();
            _healthController.Initialize();
        }
    }
}