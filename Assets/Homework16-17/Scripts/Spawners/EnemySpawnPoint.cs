using UnityEngine;
using Homework17.Behaviors;
using Homework17.Characters;
using Homework17.Game;
using System;

namespace Homework17.Spawners
{
    public class EnemySpawnPoint : SpawnPoint
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _hero;

        [SerializeField] private GameSettings.EnemyIdleBehavior _idleBehaviorType;
        [SerializeField] private GameSettings.EnemyReactBehavior _reactBehaviorType;

        private IBehavior _idleBehavior;
        private IBehavior _reactBehavior;

        public override void Initialize()
        {
            _idleBehavior = SetBehavior(_idleBehaviorType);
            _reactBehavior = SetBehavior(_reactBehaviorType);
        }

        public override void Spawn()
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = null;
            newEnemy.Initialize(_idleBehavior, _reactBehavior, _hero);
        }

        private IBehavior SetBehavior(Enum behaviorType)
        {
            switch (behaviorType)
            {
                case GameSettings.EnemyIdleBehavior.Stay:
                    return new StayBehavior();

                case GameSettings.EnemyIdleBehavior.Patrol:
                    return new PatrolBehavior();

                case GameSettings.EnemyIdleBehavior.RandomPatrol:
                    return new RandomPatrolBehavior();

                case GameSettings.EnemyReactBehavior.Chase:
                    return new ChaseBehavior();

                case GameSettings.EnemyReactBehavior.Explode:
                    return new ExplodeBehavior();

                case GameSettings.EnemyReactBehavior.RunAway:
                    return new RunAwayBehavior();

                default:
                    return new StayBehavior();
            }
        }
    }
}