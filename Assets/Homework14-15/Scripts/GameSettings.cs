using UnityEngine;

namespace Homework15
{
    public class GameSettings : MonoBehaviour
    {
        [Header("Character Settings")]
        [SerializeField] private float _characterSpeed;
        [SerializeField] private float _characterRotationSpeed;
        
        [Header("Other")]
        [SerializeField] private KeyCode _restartKey;

        public float CharacterSpeed { get { return _characterSpeed; } }

        public float CharacterRotationSpeed { get { return _characterRotationSpeed; } }

        public KeyCode RestartKey { get { return _restartKey; } }
    }
}