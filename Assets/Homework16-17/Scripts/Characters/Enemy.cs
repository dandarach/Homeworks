using UnityEngine;
using Homework17.Game;
using Homework17.Behaviors;
using Homework17.Utils;

namespace Homework17.Characters
{
    public class Enemy : MonoBehaviour
    {
        private DistanceDetector _distanceDetector;

        private IBehavior _idleBehavior;
        private IBehavior _reactBehavior;
        private IBehavior _currentBehavior;

        public void Initialize(IBehavior idleBehavior, IBehavior reactBehavior, Transform detectTarget)
        {
            _idleBehavior = idleBehavior;
            _reactBehavior = reactBehavior;

            _distanceDetector = gameObject.AddComponent<DistanceDetector>();
            _distanceDetector.Initialize(transform, detectTarget.transform, GameSettings.MinDistanceToDetect);

            SetBehavior(idleBehavior);
        }

        private void Update()
        {
            if (_distanceDetector.IsDetectStateChanged)
            {
                if (_distanceDetector.IsDetected)
                    SetBehavior(_reactBehavior);
                else
                    SetBehavior(_idleBehavior);
            }

            _currentBehavior.Process();
        }

        public void SetBehavior(IBehavior behavior) => _currentBehavior = behavior;
    }
}
 