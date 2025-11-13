using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class RunAwayAngryBehavior : IAngryBehavior
    {
       public void Attack()
        {
            Debug.Log("RunAway Attack");
        }
    }
}
