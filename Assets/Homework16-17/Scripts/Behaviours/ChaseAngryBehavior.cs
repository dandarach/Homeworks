using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class ChaseAngryBehavior : IAngryBehavior
    {
       public void Attack()
        {
            Debug.Log("Chase Attack");
        }
    }
}
