using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class RandomPatrolIdleBehavior : IIdleBehavior
    {
       public void Idle()
        {
            Debug.Log("Idle Random Patrol");
        }
    }
}
