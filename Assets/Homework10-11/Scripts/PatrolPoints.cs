using System.Collections.Generic;
using UnityEngine;

namespace Homework11
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] private int _patrolPointsNumber;
        [SerializeField] private Vector3 _minCoordinates;
        [SerializeField] private Vector3 _maxCoordinates;
        [SerializeField] private GameObject _currentTargetVisual;

        private Queue<Vector3> _patrolPointsPositions;

        public Vector3 CurrentPatrolPointPosition { get; private set; }

        public void Initialize()
        {
            _patrolPointsPositions = new Queue<Vector3>();
            SetRandomPatrolPionts();
            SwitchPatrolPoint();
        }

        private void SetRandomPatrolPionts()
        {
            Debug.Log("PatrolPoints:");

            for (var i = 0; i < _patrolPointsNumber; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(_minCoordinates.x, _maxCoordinates.x),
                    Random.Range(_minCoordinates.y, _maxCoordinates.y),
                    Random.Range(_minCoordinates.z, _maxCoordinates.z)
                );

                _patrolPointsPositions.Enqueue(randomPosition);

                Debug.Log($"PatrolPoint {i}: {randomPosition}");
            }
        }

        public void SwitchPatrolPoint()
        {
            Debug.Log("SwitchPatrolPoint()");
            CurrentPatrolPointPosition = _patrolPointsPositions.Dequeue();
            _patrolPointsPositions.Enqueue(CurrentPatrolPointPosition);

            if (_currentTargetVisual != null)
                _currentTargetVisual.transform.position = CurrentPatrolPointPosition;
        }
    }
}