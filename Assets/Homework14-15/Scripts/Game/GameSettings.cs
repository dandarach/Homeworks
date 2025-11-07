using UnityEngine;

namespace Homework15.Game
{
    public class GameSettings : MonoBehaviour
    {
        [Header("Character Settings")]
        [SerializeField] private float _characterInitialSpeed;
        [SerializeField] private float _characterMaximumSpeed;
        [SerializeField] private float _characterRotationSpeed;
        [SerializeField] private int _initialHealth;

        [Header("Spawner")]
        [SerializeField] private float _itemSpawnCooldown;
        
        
        [Header("Other")]
        [SerializeField] private KeyCode _restartKey;
        [SerializeField] private KeyCode _useItemKey;

        public float CharacterInitialSpeed { get { return _characterInitialSpeed; } }

        public float CharacterMaximumSpeed { get { return _characterMaximumSpeed; } }
        
        public float CharacterRotationSpeed { get { return _characterRotationSpeed; } }
        
        public int InitialHealth { get { return _initialHealth; } }
        
        public float ItemSpawnCooldown { get { return _itemSpawnCooldown; } }

        public KeyCode RestartKey { get { return _restartKey; } }

        public KeyCode UseItemKey { get { return _useItemKey; } }
    }
}