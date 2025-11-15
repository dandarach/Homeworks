using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Mover _mover;

        protected void Update()
        {
            Vector3 direction = GetDirection();
            
            if (direction.magnitude > GameSettings.DeadZone)
                _mover.MoveAndRotate(direction);
        }

        protected abstract Vector3 GetDirection();
    }
}