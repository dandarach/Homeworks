using UnityEngine;
using Homework17.Behaviors;
using Homework17.Spawners;

namespace Homework17.Characters
{
    public class Enemy : MonoBehaviour
    {
        private IIdleBehavior _idleBehavior;
        private IAngryBehavior _angryBehavior;

        public void Initialize(IIdleBehavior idleBehavior, IAngryBehavior angryBehavior)
        {
            _idleBehavior = idleBehavior;
            _angryBehavior = angryBehavior;
        }

        public void Idle() => _idleBehavior.Idle();

        public void Attack() => _angryBehavior.Attack();
    }
}
