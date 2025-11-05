using UnityEngine;

namespace Homework11
{
    public class CharacterAnimator : MonoBehaviour
    {
        private const string WinTrigger = "Win";
        private const string DieTrigger = "Die";
        private const string RestartTrigger = "Restart";

        [SerializeField] private Animator _animator;

        private void Awake()
        {
            Debug.Log("--- AWAKE CHARACTER ANIMATOR ---");
        }

        public void Restart() => _animator.SetTrigger(RestartTrigger);

        public void PlayWinAnimation() => _animator.SetTrigger(WinTrigger);

        public void PlayDieAnimation() => _animator.SetTrigger(DieTrigger);
    }
}