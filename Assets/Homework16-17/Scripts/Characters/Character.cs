using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public class Character : MonoBehaviour
    {
        private CharacterMover _characterMover;
        
        public void Initialize(float characterSpeed, float characterRotationSpeed)
        {
            _characterMover = new CharacterMover();

            bool IsCharacterControllerExists = TryGetComponent<CharacterController>(out CharacterController characterController);

            if (IsCharacterControllerExists)
            {
                _characterMover.Initialize(characterController, characterSpeed, characterRotationSpeed);
            }
            else
            {
                Debug.LogError("Character. Unable to get CharacterController");
            }
        }

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(GameSettings.HorizontalAxisName), 0, Input.GetAxisRaw(GameSettings.VerticalAxisName));

            if (input.magnitude <= GameSettings.DeadZone)
                return;

            _characterMover.RotateAndMoveTo(input);
        }
    }
}