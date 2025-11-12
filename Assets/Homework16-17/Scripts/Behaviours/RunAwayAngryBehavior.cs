using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class RunAwayAngryBehaviour : IAngryBehavior
    {
       public void Attack()
        {
            Debug.Log("RunAway Attack");
        }
    }
}
