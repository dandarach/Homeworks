using UnityEngine;

namespace Homework11
{
    public class Enemy : MonoBehaviour
    {
        private const float MinDistanceToTarget = 0.5f;

        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private PatrolPoints _patrolPoints;
        [SerializeField] private CharacterAnimator _characterAnimator;

        private CharacterMover _characterMover;

        public Vector3 Direction { get; private set; }

        public bool IsPatroling { get; private set; }

        public void Initialize()
        {
            _characterMover = new CharacterMover();
            _characterMover.Initialize(GetComponent<CharacterController>(), _speed, _rotationSpeed);

            _patrolPoints.Initialize();
            IsPatroling = false;
        }
        private void Awake()
        {
            Debug.Log("--- AWAKE Enemy ---");
        }

        private void Update()
        {
            if (IsPatroling == false)
                return;

            Direction = GetDirectionToPatrolPoint();

            if (Direction.magnitude < MinDistanceToTarget)
                _patrolPoints.SwitchPatrolPoint();

            _characterMover.RotateAndMoveTo(Direction);
        }
        public void Patrol() => IsPatroling = true;

        public void Stop() => IsPatroling = false;

        private Vector3 GetDirectionToPatrolPoint() => _patrolPoints.CurrentPatrolPointPosition - transform.position;

        public void Kill()
        {
            Stop();
            _characterAnimator.PlayDieAnimation();
        }

        public void Win()
        {
            Stop();
            _characterAnimator.PlayWinAnimation();
        }

        public void Reborn()
        {
            _patrolPoints.Initialize();
            _characterMover.ResetTransform();
            _characterAnimator.Restart();
            _patrolPoints.SwitchPatrolPoint();
        }
    }
}