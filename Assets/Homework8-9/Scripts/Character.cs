using System;
using UnityEngine;

namespace GhostGame
{
    public class Character : MonoBehaviour
    {
        private const KeyCode JumpUpKey = KeyCode.UpArrow;
        private const KeyCode JumpLeftKey = KeyCode.LeftArrow;
        private const KeyCode JumpRightKey = KeyCode.RightArrow;

        [SerializeField] private Vector3 _jumpForceUp;
        [SerializeField] private Vector3 _jumpForceSide;
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private CharacterEffects _characterEffects;

        private Rigidbody _rigidbody;
        private bool _isRunning;

        public int JumpUpCount { get; private set; }
        public int JumpSideCount { get; private set; }
        public Vector3 SavedPosition { get; private set; }

        private void Awake()
        {
            Debug.Log("--- CHARACTER.AWAKE ---");
            _rigidbody = GetComponent<Rigidbody>();
            DisableMovement();
        }

        public void Initialize()
        {
            JumpUpCount = JumpSideCount = 0;
            ResetPosition();
            EnableMovement();
            ResetSpeed();

            _characterAnimator.JumpUp();
            _characterAnimator.Restart();
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(JumpUpKey))
            {
                _rigidbody.AddForce(_jumpForceUp, ForceMode.Impulse);
                JumpUpCount++;
                _characterAnimator.JumpUp();
                _characterEffects.PlayJumpEffect();
            }
            else if (Input.GetKeyDown(JumpLeftKey))
            {
                _rigidbody.AddForce(-_jumpForceSide, ForceMode.Impulse);
                JumpSideCount++;
                _characterAnimator.TurnLeft();
            }
            else if (Input.GetKeyDown(JumpRightKey))
            {
                _rigidbody.AddForce(_jumpForceSide, ForceMode.Impulse);
                JumpSideCount++;
                _characterAnimator.TurnRight();
            }
        }

        public void Win()
        {
            Debug.LogWarning("*** Win ***");
            DisableMovement();
            _characterAnimator.PlayWinAnimation();
            _characterEffects.PlayWinEffect();
        }

        public void Die()
        {
            Debug.LogWarning("*** Kill ***");
            DisableMovement();
            _characterAnimator.PlayDieAnimation();
            _characterEffects.Explode();
        }

        public void ResetSpeed()
        {
            _rigidbody.velocity = Vector3.zero;
            _characterEffects.ResetEffects();
        }

        public void EnableMovement()
        {
            _rigidbody.isKinematic = false;
            _isRunning = true;
        }

        public void DisableMovement()
        {
            _rigidbody.isKinematic = true;
            _isRunning = false;
        }

        public void SavePosition()
        {
            SavedPosition = gameObject.transform.position;
            Debug.Log($"* SavedPosition: {SavedPosition}");
        }

        public void ResetPosition()
        {
            gameObject.transform.position = SavedPosition;
            Debug.Log($"* ResetPosition: {SavedPosition}");
        }
    }
}