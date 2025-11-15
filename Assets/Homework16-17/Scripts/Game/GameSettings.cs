using UnityEngine;

namespace Homework17.Game
{
    public class GameSettings : MonoBehaviour
    {
        public const float MinDistanceToDetect = 5.0f;

        public const float DeadZone = 0.1f;
        public const string HorizontalAxisName = "Horizontal";
        public const string VerticalAxisName = "Vertical";

        public const float CharacterSpeed = 5.0f;
        public const float CharacterRotationSpeed = 700.0f;

        public enum IdleBehavior
        {
            Stay,
            Patrol,
            RandomPatrol
        }

        public enum ReactBehavior
        {
            Chase,
            RunAway,
            Explode
        }
    }
}