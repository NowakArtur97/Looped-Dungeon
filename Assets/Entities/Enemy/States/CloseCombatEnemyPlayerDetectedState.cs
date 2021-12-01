using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class CloseCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        private CloseCombatEnemy _closeCombatEnemy;

        public CloseCombatEnemyPlayerDetectedState(CloseCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _closeCombatEnemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    Entity.StateMachine.ChangeState(_closeCombatEnemy.MeleeAttackState);
                }
                else if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(_closeCombatEnemy.ChargePlayerState);
                }
            }
        }
    }
}
