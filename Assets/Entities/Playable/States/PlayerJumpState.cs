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

            _player.CoreContainer.Input.UseJumpInput();

            _player.CoreContainer.Movement.SetVelocityY(Entity.Data.jumpVelocity);

            Entity.CoreContainer.Animator.SetFloat("velocityX", Entity.CoreContainer.Movement.CurrentVelocity.x);
            Entity.CoreContainer.Animator.SetFloat("velocityY", Entity.CoreContainer.Movement.CurrentVelocity.y);

            IsAbilityFinished = true;
        }
    }
}
