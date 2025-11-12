using UnityEngine;
using Homework17.Game;

namespace Homework17.Spawners
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameSettings.EnemyIdleBehavior _enemyIdleBehavior;
        [SerializeField] private GameSettings.EnemyAngryBehavior _enemyAngryBehavior;

        public GameSettings.EnemyIdleBehavior IdleBehavior => _enemyIdleBehavior;

        public GameSettings.EnemyAngryBehavior AngryBehavior => _enemyAngryBehavior;
    }
}