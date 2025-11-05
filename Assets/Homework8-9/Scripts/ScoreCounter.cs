using UnityEngine;

namespace GhostGame
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private int _jumpUpScore;
        [SerializeField] private int _jumpSideScore;
        [SerializeField] private Character _character;

        private void Awake()
        {
            Debug.Log("--- SCORE COUNTER.AWAKE ---");
        }

        public int GetCurrentScores()
        {
            int scores = _character.JumpUpCount * _jumpUpScore + _character.JumpSideCount * _jumpSideScore;
            Debug.Log($"Scores: {scores}");
            return scores;
        }
    }
}