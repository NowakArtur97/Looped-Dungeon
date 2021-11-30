using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyPlayerDetectedState : EnemyGroundedState
    {
        public EnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                // TODO: EnemyPlayerDetectedState: Change based on Enemy
                if (IsPlayerInMinAgroRange)
                {

                }
                // TODO: EnemyPlayerDetectedState: Change based on Enemy
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
