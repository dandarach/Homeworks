using UnityEngine;
using Homework17.Game;
using Homework17.Behaviors;
using Homework17.Utils;

namespace Homework17.Characters
{
    public class Enemy : MonoBehaviour
    {
        private DistanceDetector _distanceDetector;
        private Transform _heroTransform;

        private IIdleBehavior _idleBehavior;
        private IAngryBehavior _angryBehavior;

        public void Initialize(IIdleBehavior idleBehavior, IAngryBehavior angryBehavior)
        {
            SetBehavior(idleBehavior, angryBehavior);

            Hero hero = FindObjectOfType<Hero>();

            if (hero == null)
            {
                Debug.LogError("Unable to find Hero");
            }
            else
            {
                _heroTransform = hero.transform;
                _distanceDetector = gameObject.AddComponent<DistanceDetector>();
                _distanceDetector.Initialize(transform, _heroTransform, GameSettings.MinDistanceToDetect);
            }
        }

        private void Update()
        {
            if (_distanceDetector.IsDetectStateChanged)
            {
                if (_distanceDetector.IsDetected)
                    Debug.Log("Attack()");
                else
                    Debug.Log("Idle()");
            }
        }

        public void SetBehavior(IIdleBehavior idleBehavior, IAngryBehavior angryBehavior)
        {
            _idleBehavior = idleBehavior;
            _angryBehavior = angryBehavior;
        }

        public void Idle() => _idleBehavior.Idle();

        public void Attack() => _angryBehavior.Attack();
    }
}
 