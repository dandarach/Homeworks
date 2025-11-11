using UnityEngine;

namespace Homework15.Game
{
    public class GameSettings : MonoBehaviour
    {
        [Header("Spawner")]
        [SerializeField] private float _itemSpawnCooldown;
        
        
        [Header("Other")]
        [SerializeField] private KeyCode _restartKey;
        [SerializeField] private KeyCode _useItemKey;

        public float ItemSpawnCooldown { get { return _itemSpawnCooldown; } }

        public KeyCode RestartKey { get { return _restartKey; } }

        public KeyCode UseItemKey { get { return _useItemKey; } }
    }
}