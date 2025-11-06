using UnityEngine;

namespace Homework15
{
    public class ItemsCollector : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;

        private void OnTriggerEnter(Collider other)
        {
            Item triggeredItem = other.GetComponent<Item>();

            if (triggeredItem != null)
            {
                _scoreCounter.CollectItem(triggeredItem);
            }
        }
    }
}