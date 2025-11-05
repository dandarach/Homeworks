using UnityEditor.Animations;
using UnityEngine;

namespace GhostGame
{
    public class Boundary : MonoBehaviour
    {
        [SerializeField] private float _topLimit;
        [SerializeField] private float _bottomLimit;
        [SerializeField] private float _leftLimit;
        [SerializeField] private float _rightLimit;

        [SerializeField] private GameObject _topBoundary;
        [SerializeField] private GameObject _bottomBoundary;
        [SerializeField] private GameObject _leftBoundary;
        [SerializeField] private GameObject _rightBoundary;

        [SerializeField] private SpikesAnimator _spikesAnimator;

        private void Awake()
        {
            Debug.Log("--- BOUNDARY.AWAKE ---");
        }

        public void Initialize()
        {
            _topBoundary.transform.position = new Vector3(0, _topLimit, 0);
            _bottomBoundary.transform.position = new Vector3(0, _bottomLimit, 0);
            _leftBoundary.transform.position = new Vector3(_leftLimit, 0, 0);
            _rightBoundary.transform.position = new Vector3(_rightLimit, 0, 0);
        }

        public bool IsOutOfBoundary(Vector3 position)
            => position.y > _topLimit || position.y < _bottomLimit || position.x < _leftLimit || position.x > _rightLimit;

        public void EnableEffect() => _spikesAnimator.Enable();

        public void DisableEffect() => _spikesAnimator.Disable();
    }
}