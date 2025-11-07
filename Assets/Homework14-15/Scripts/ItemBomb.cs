using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemBomb : Item
    {
        public override void Use()
        {
            base.Use();

            Debug.Log($"* Bomb used");
        }
    }
}