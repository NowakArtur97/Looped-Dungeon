using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class RangedCombatEnemyHurtState : HurtState
    {
        private Enemy _enemy;

        public RangedCombatEnemyHurtState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && IsAnimationFinished)
            {
                _enemy.BackOffState.ShouldStartMoving = true;
                Entity.StateMachine.ChangeState(_enemy.BackOffState);
            }
        }
    }
}
