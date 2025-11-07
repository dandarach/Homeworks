using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15.Items
{
    public class ItemBottle : Item
    {
        public override void Use()
        {
            base.Use();

            Debug.Log($"* Bottle used");
        }
    }
}