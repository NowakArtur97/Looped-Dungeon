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
                if (!IsPlayerInMaxAgro)
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
