using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public abstract class Character : MonoBehaviour
    {
        private Mover _mover;

        public virtual void Initialize(float speed, float rotationSpeed)
        {
            _mover = new Mover();
            _mover.Initialize(transform, speed, rotationSpeed);
        }

        protected void Update()
        {
            Vector3 direction = GetDirection();
            
            if (direction.magnitude > GameSettings.DeadZone)
                _mover.MoveAndRotate(direction);
        }

        //protected abstract void OnMove(Vector3 direction);

        protected abstract Vector3 GetDirection();
    }
}