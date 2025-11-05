using System;
using UnityEngine;

namespace Homework13B
{
    public class Game : MonoBehaviour
    {
        private const KeyCode RestartKey = KeyCode.R;

        [SerializeField] private Character _character;
        [SerializeField] private DeskRotator _deskRotator;

        public void Initialize()
        {
            Debug.Log("*** Welcome! ***");
            Debug.Log($"Press {RestartKey} to restart game");

            _character.ResetState();
            _deskRotator.ResetState();
        }

        private void Update()
        {
            if (Input.GetKeyDown(RestartKey))
                Initialize();
        }
    }
}
