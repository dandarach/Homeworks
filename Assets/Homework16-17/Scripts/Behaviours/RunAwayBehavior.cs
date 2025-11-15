using UnityEngine;
using Homework17.Behaviors;
using Homework17.Characters;

namespace Homework17.Behaviors
{
    public class RunAwayBehavior : IBehavior
    {
        private Mover _mover;
        private Transform _hero;

        public RunAwayBehavior(Mover mover, Transform hero)
        {
            _mover = mover;
            _hero = hero;
        }

        public void Process()
        {
            //Vector3 d = new Vector3(_hero.position.x, 0, _hero.position.z);
            Vector3 direction = _mover.transform.position - _hero.position;
            _mover.MoveTo(direction);
        }
    }
}
