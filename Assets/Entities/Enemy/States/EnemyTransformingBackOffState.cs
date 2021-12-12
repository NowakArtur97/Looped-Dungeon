using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyTransformingBackOffState : EnemyBackOffState
    {
        public EnemyTransformingBackOffState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsPlayerInMaxAgroRange && HasEscaped)
                {
                    Entity.StateMachine.ChangeState(Enemy.TransformState);
                }
                else if (IsPlayerInMaxAgroRange && !IsPlayerInMinAgroRange && !ShouldIgnoreClosePlayer && HasEscaped)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else if (!IsGrounded || IsCloseToWall || HasEscaped)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }

    }
}
