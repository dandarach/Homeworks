using UnityEngine;
using Homework17.Behaviors;
using Homework17.Characters;
using Homework17.Game;

namespace Homework17.Spawners
{
    public class EnemySpawnPoint : SpawnPoint
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private GameSettings.EnemyIdleBehavior _enemyIdleBehavior;
        [SerializeField] private GameSettings.EnemyAngryBehavior _enemyAngryBehavior;

        private IIdleBehavior _idleBehavior;
        private IAngryBehavior _angryBehavior;

        public override void Initialize()
        {
            _idleBehavior = SetIdleBehavior();
            _angryBehavior = SetAngryBehavior();
        }

        public override void Spawn()
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = null;
            newEnemy.Initialize(_idleBehavior, _angryBehavior);
        }

        private IIdleBehavior SetIdleBehavior()
        {
            switch (_enemyIdleBehavior)
            {
                case GameSettings.EnemyIdleBehavior.Stay:
                    return new StayIdleBehavior();

                case GameSettings.EnemyIdleBehavior.Patrol:
                    return new PatrolIdleBehavior();

                case GameSettings.EnemyIdleBehavior.RandomPatrol:
                    return new RandomPatrolIdleBehavior();

                default:
                    return new StayIdleBehavior();
            }
        }

        private IAngryBehavior SetAngryBehavior()
        {
            switch (_enemyAngryBehavior)
            {
                case GameSettings.EnemyAngryBehavior.Chase:
                    return new ChaseAngryBehavior();

                case GameSettings.EnemyAngryBehavior.Explode:
                    return new ExplodeAngryBehavior();

                case GameSettings.EnemyAngryBehavior.RunAway:
                    return new RunAwayAngryBehavior();

                default:
                    return new ChaseAngryBehavior();
            }
        }
    }
}