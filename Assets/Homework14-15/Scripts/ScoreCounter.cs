using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private int _starScore;
        [SerializeField] private List<Item> _items;
        [SerializeField] private TextUI _scoreUI;

        public int ItemsNumber { get; private set; }

        public int Scores { get; private set; }

        public bool IsAllItemsCollected { get; private set; }

        public void Initialize()
        {
            ItemsNumber = _items.Count;
            ResetState();
            IsAllItemsCollected = false;

            for (int i =  0; i < ItemsNumber; i++)
            {
                _items[i].Score = _starScore;
            }
        }

        public void CollectItem(Item item)
        {
            Scores += _starScore;
            UpdateScoreUI();

            item.Collect();
            ItemsNumber--;
            Debug.Log($"- Item collected. Items number: {_items.Count}");

            if (ItemsNumber == 0)
                IsAllItemsCollected = true;
        }

        public void ResetState()
        {
            Scores = 0;
            RestoreItems();
            UpdateScoreUI();
        }

        private void RestoreItems()
        {
            foreach (Item item in _items)
                item.Enable();
        }

        private void UpdateScoreUI()
        {
            _scoreUI.PrintText(Scores.ToString());
        }
    }
}