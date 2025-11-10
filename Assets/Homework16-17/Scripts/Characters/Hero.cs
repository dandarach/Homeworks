using UnityEngine;
using Homework17.Game;

namespace Homework17.Characters
{
    public class Hero : Character
    {
        protected override Vector3 GetDirection()
            => new Vector3(Input.GetAxisRaw(GameSettings.HorizontalAxisName), 0, Input.GetAxisRaw(GameSettings.VerticalAxisName));
    }
}
