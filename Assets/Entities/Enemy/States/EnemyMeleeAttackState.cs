using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyMeleeAttackState : EnemyAttackState
    {
        public EnemyMeleeAttackState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void TriggerAttack() => DamageEnemies();

        private void DamageEnemies() => Enemy.HitboxesToEnemyAttackState.ToDamage
            .ForEach(damagable => damagable.Damage(Enemy.CloseCombatEnemyData.meleeAttackDamage));
    }
}
