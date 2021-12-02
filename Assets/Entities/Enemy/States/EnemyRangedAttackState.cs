using NowakArtur97.LoopedDungeon.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyRangedAttackState : EnemyAttackState
    {
        private RangedCombatEnemy _rangedCombatEnemy;

        public EnemyRangedAttackState(RangedCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _rangedCombatEnemy = entity;
        }

        public override void TriggerAttack() => SpawnProjectile();

        private void SpawnProjectile() => GameObject.Instantiate(_rangedCombatEnemy.Projectile,
            _rangedCombatEnemy.ProjectileSpawnPosition.position, Quaternion.identity);
    }
}
