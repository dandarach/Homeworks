using UnityEngine;

namespace Homework15
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private KeyCode _restartKey;

        public KeyCode RestartKey { get { return _restartKey; } }
    }
}