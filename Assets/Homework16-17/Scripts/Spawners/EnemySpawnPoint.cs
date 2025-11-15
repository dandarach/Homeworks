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
        [SerializeField] private Hero _hero;

        [SerializeField] private GameSettings.IdleBehavior _idleBehaviorType;
        [SerializeField] private GameSettings.ReactBehavior _reactBehaviorType;

        public override void Spawn()
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = null;

            IBehavior idleBehavior = CreateBehavior(_idleBehaviorType, newEnemy);
            IBehavior reactBehavior = CreateBehavior(_reactBehaviorType, newEnemy);

            newEnemy.Initialize(idleBehavior, reactBehavior, _hero.transform);
        }

        private IBehavior CreateBehavior(Enum behaviorType, Enemy enemy)
        {
            switch (behaviorType)
            {
                case GameSettings.IdleBehavior.Stay:
                    return new StayBehavior();

                case GameSettings.IdleBehavior.Patrol:
                    return new PatrolBehavior();

                case GameSettings.IdleBehavior.RandomPatrol:
                    return new RandomPatrolBehavior();

                case GameSettings.ReactBehavior.Chase:
                    return new ChaseBehavior();

                case GameSettings.ReactBehavior.Explode:
                    return new ExplodeBehavior();

                case GameSettings.ReactBehavior.RunAway:
                    Mover enemyMover = enemy.GetComponent<Mover>();

                    if (enemyMover == null)
                    {
                        Debug.LogError("Unable to get Mover component");
                        return null;
                    }
                    else
                    {
                        return new RunAwayBehavior(enemyMover, _hero.transform);
                    }

                default:
                    return new StayBehavior();
            }
        }
    }
}