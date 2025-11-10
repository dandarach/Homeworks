using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public class Character : MonoBehaviour
    {
        private ObjectMover _characterMover;
        
        public virtual void Initialize(float speed, float rotationSpeed)
        {
            _characterMover = new ObjectMover();
            _characterMover.Initialize(gameObject, speed, rotationSpeed);
        }

        protected virtual void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(GameSettings.HorizontalAxisName), 0, Input.GetAxisRaw(GameSettings.VerticalAxisName));

            if (input.magnitude <= GameSettings.DeadZone)
                return;

            _characterMover.Move(input);
        }
    }
}