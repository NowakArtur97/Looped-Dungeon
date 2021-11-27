using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyMoveState : GroundedState
    {
        private Enemy _enemy;

        public EnemyMoveState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * Entity.CoreContainer.Movement.FacingDirection);

            if (!IsExitingState)
            {
                if (!IsGrounded || IsTouchingWall)
                {
                    Entity.StateMachine.ChangeState(_enemy.IdleState);
                }
            }
        }
    }
}
