using UnityEngine;

namespace Homework15
{
    public class ItemsCollector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null)
            {
                Debug.Log($"Item Triggered");
                triggeredItem.Collect();
            }
        }
    }
}