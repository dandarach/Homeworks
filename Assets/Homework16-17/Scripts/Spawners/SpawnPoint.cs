using UnityEngine;
using Homework17.Behaviors;
using Homework17.Characters;
using Homework17.Game;
using static Homework17.Game.GameSettings;

namespace Homework17.Spawners
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private GameSettings.EnemyIdleBehavior _enemyIdleBehavior;
        [SerializeField] private GameSettings.EnemyAngryBehavior _enemyAngryBehavior;

        public GameSettings.EnemyIdleBehavior IdleBehavior => _enemyIdleBehavior;

        public GameSettings.EnemyAngryBehavior AngryBehavior => _enemyAngryBehavior;

        public void Spawn()
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            
           // switch (_enemyIdleBehavior.Stay):
            
           // newEnemy.Initialize(new PatrolIdleBehavior(), _enemyAngryBehavior);
        }
    }
}