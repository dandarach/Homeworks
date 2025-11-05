using UnityEngine;

namespace GhostGame
{
    public class CharacterAnimator : MonoBehaviour
    {
        private const string Direction = "Direction";
        private const string JumpUpTrigger = "JumpUp";
        private const string WinTrigger = "Win";
        private const string DieTrigger = "Die";
        private const string RestartTrigger = "Restart";

        public const int Up = 1;
        public const int Left = 2;
        public const int Right = 3;

        private Animator _animator;

        private void Awake()
        {
            Debug.Log("--- CHARACTER ANIMATOR.AWAKE ---");
            _animator = gameObject.GetComponent<Animator>();
        }

        public void Restart()
        {
            _animator.SetTrigger(RestartTrigger);
        }

        public void PlayWinAnimation()
        {
            ResetDirection();
            _animator.SetTrigger(WinTrigger);
        }

        public void PlayDieAnimation()
        {
            _animator.SetTrigger(DieTrigger);
        }

        public void JumpUp()
        {
            ResetDirection();
            _animator.SetTrigger(JumpUpTrigger);
        }

        public void TurnLeft()
        {
            _animator.SetInteger(Direction, Left);
        }

        public void TurnRight()
        {
            _animator.SetInteger(Direction, Right);
        }

        public void ResetDirection()
        {
            _animator.SetInteger(Direction, Up);
        }
    }
}