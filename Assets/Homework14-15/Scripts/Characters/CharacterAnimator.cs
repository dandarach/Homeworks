using UnityEngine;

namespace Homework15.Characters
{
    public class CharacterAnimator : MonoBehaviour
    {
        private const string WinTrigger = "Win";
        private const string DieTrigger = "Die";
        private const string RestartTrigger = "Restart";

        [SerializeField] private Animator _animator;

        public void Restart() => _animator.SetTrigger(RestartTrigger);

        public void PlayWinAnimation() => _animator.SetTrigger(WinTrigger);

        public void PlayDieAnimation() => _animator.SetTrigger(DieTrigger);
    }
}