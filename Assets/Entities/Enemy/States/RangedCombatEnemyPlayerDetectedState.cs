using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class RangedCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        private RangedCombatEnemy _rangedCombatEnemy;

        public RangedCombatEnemyPlayerDetectedState(RangedCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _rangedCombatEnemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(_rangedCombatEnemy.BackOffState);
                }
                else if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(_rangedCombatEnemy.RangedAttackState);
                }
            }
        }
    }
}
