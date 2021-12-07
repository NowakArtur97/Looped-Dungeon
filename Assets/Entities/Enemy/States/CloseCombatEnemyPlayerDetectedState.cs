using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class CloseCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        public CloseCombatEnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.MeleeAttackState);
                }
                else if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.ChargePlayerState);
                }
                else
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
