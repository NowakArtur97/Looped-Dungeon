using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerJumpState : AbilityState
    {
        private Player _player;

        public PlayerJumpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void Enter()
        {
            base.Enter();

            _player.CoreContainer.Movement.SetVelocityY(Entity.Data.jumpVelocity);

            Entity.CoreContainer.Animation.SetVelocityVariable();

            IsAbilityFinished = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsAbilityFinished)
                {
                    if (IsGrounded)
                    {
                        _player.StateMachine.ChangeState(_player.IdleState);
                    }
                    else
                    {
                        _player.StateMachine.ChangeState(_player.InAirState);
                    }
                }
            }
        }
    }
}
