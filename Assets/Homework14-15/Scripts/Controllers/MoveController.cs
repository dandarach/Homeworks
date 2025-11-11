using UnityEngine;
using Homework15.Characters;

namespace Homework15.Controllers
{
    public class MoveController : MonoBehaviour
    {
        private const float DeadZone = 0.1f;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        [SerializeField] private float _characterInitialSpeed;
        [SerializeField] private float _characterMaximumSpeed;
        [SerializeField] private float _characterRotationSpeed;

        private CharacterMover _characterMover;

        public void Initialize()
        {
            _characterMover = new CharacterMover();
            
            CharacterController characterController = GetComponent<CharacterController>();

            if (characterController != null)
                _characterMover.Initialize(characterController, _characterInitialSpeed, _characterMaximumSpeed, _characterRotationSpeed);
            else
                Debug.LogError("Character. Unable to get CharacterController");
        }

        public void SpeedUp(float additionalSpeed)
        {
            _characterMover.Accelerate(additionalSpeed);
            Debug.Log($"SpeedUp: {additionalSpeed}. Total Speed: {_characterMover.Speed}");
        }

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            if (input.magnitude <= DeadZone)
                return;
            
            _characterMover.RotateAndMoveTo(input);
        }
    }
}