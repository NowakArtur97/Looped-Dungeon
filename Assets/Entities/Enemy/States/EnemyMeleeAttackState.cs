using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyMeleeAttackState : EnemyAttackState
    {
        private CloseCombatEnemy _closeCombatEnemy;

        public EnemyMeleeAttackState(CloseCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _closeCombatEnemy = entity;
        }

        public override void TriggerAttack() => DamageEnemies();

        private void DamageEnemies() => Enemy.HitboxesToEnemyAttackState.ToDamage
            .ForEach(damagable => damagable.Damage(_closeCombatEnemy.MeleeAttackDamage));
    }
}
