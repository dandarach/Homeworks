using UnityEngine;

namespace Homework15
{
    public class GameSettings : MonoBehaviour
    {
        [Header("Character Settings")]
        [SerializeField] private float _characterSpeed;
        [SerializeField] private float _characterRotationSpeed;

        [Header("Spawner")]
        [SerializeField] private float _itemSpawnCooldown;
        
        
        [Header("Other")]
        [SerializeField] private KeyCode _restartKey;
        [SerializeField] private KeyCode _useItemKey;

        public float CharacterSpeed { get { return _characterSpeed; } }

        public float CharacterRotationSpeed { get { return _characterRotationSpeed; } }
        
        public float ItemSpawnCooldown { get { return _itemSpawnCooldown; } }

        public KeyCode RestartKey { get { return _restartKey; } }

        public KeyCode UseItemKey { get { return _useItemKey; } }
    }
}