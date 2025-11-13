using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public abstract class Character : MonoBehaviour
    {
        private CharacterMover _characterMover;

        public virtual void Initialize(float speed, float rotationSpeed)
        {
            _characterMover = new CharacterMover();

            bool IsCharacterControllerExists = TryGetComponent<CharacterController>(out CharacterController characterController);

            if (IsCharacterControllerExists)
                _characterMover.Initialize(characterController, speed, rotationSpeed);
            else
                Debug.LogError("Unable to get CharacterController");
        }

        protected void Update()
        {
            Vector3 direction = GetDirection();
            
            if (direction.magnitude > GameSettings.DeadZone)
                _characterMover.MoveAndRotate(direction);
        }

        protected abstract Vector3 GetDirection();
    }
}