using UnityEngine;
using Homework17.Behaviors;

namespace Homework17.Behaviors
{
    public class StayBehavior : IBehavior
    {
       public void Process()
        {
            Debug.Log("Stay");
        }
    }
}
