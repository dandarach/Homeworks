using UnityEngine;

namespace Homework17.Game
{
    public class GameSettings : MonoBehaviour
    {
        public const float DeadZone = 0.1f;
        public const string HorizontalAxisName = "Horizontal";
        public const string VerticalAxisName = "Vertical";

        [SerializeField] public static readonly float CharacterSpeed;
        [SerializeField] public static readonly float CharacterRotationSpeed;
    }
}