using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ItemCoin : Item
    {
        public override void Use()
        {
            base.Use();

            Debug.Log($"* Coin used");
        }
    }
}