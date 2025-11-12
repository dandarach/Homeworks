using Homework15.Spawners;
using Homework17.Characters;
using Homework17.Game;
using UnityEngine;

namespace Homework17.Spawners
{
    public class EnemySpawnPoint : SpawnPoint
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private GameSettings.EnemyIdleBehavior _enemyIdleBehavior;
        [SerializeField] private GameSettings.EnemyAngryBehavior _enemyAngryBehavior;

        public GameSettings.EnemyIdleBehavior IdleBehavior => _enemyIdleBehavior;

        public GameSettings.EnemyAngryBehavior AngryBehavior => _enemyAngryBehavior;

        public override void Spawn()
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}