using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class PatrolIdleBehavior : IIdleBehavior
    {
       public void Idle()
        {
            Debug.Log("Idle Patrol");
        }
    }
}
