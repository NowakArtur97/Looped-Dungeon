using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerTossUpState : PlayerAbilityState
    {
        private bool _isCrouching;

        public PlayerTossUpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Movement.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();

            _isCrouching = true;
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();

            _isCrouching = true;
        }
    }
}
