using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyMoveState : EnemyGroundedState
    {
        public EnemyMoveState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * Entity.CoreContainer.Movement.FacingDirection);

            if (!IsExitingState)
            {
                if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else if (!IsGrounded || IsCloseToWall)
                {
                    Entity.StateMachine.ChangeState(Enemy.IdleState);
                }
            }
        }
    }
}
