using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyMeleeAttackState : EnemyAttackState
    {
        private CloseRangeAbility _mainAbility;

        public EnemyMeleeAttackState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void TriggerAttack() => Enemy.HitboxesToEnemyAttackState.ToDamage.ForEach(damagable => damagable.Damage(Enemy.EnemyData.meleeAttackDamage));

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            IsAbilityFinished = true;
        }
    }
}
