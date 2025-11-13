using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class ExplodeAngryBehavior : IAngryBehavior
    {
       public void Attack()
        {
            Debug.Log("Explode Attack");
        }
    }
}
