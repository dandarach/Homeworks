using UnityEngine;

namespace Homework17.Game
{
    public class GameSettings : MonoBehaviour
    {
        public const float DeadZone = 0.1f;
        public const string HorizontalAxisName = "Horizontal";
        public const string VerticalAxisName = "Vertical";

        public const float CharacterSpeed = 5f;
        public const float CharacterRotationSpeed = 700f;

        public enum EnemyIdleBehavior
        {
            Stay,
            Patrol,
            RandomPatrol
        }

        public enum EnemyAngryBehavior
        {
            Chase,
            RunAway,
            Explode
        }
    }
}