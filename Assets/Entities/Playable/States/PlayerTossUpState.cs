using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerTossUpState : PlayerAbilityState
    {
        private bool _isCrouching;
        private bool _abilityInput;

        public PlayerTossUpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Movement.SetVelocityX(0);
        }

        public override void Exit()
        {
            base.Exit();

            _isCrouching = false;
            _abilityInput = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _abilityInput = Player.CoreContainer.Input.SecondaryAbilityInput;

            if (_isCrouching && !_abilityInput)
            {
                IsAbilityFinished = true;
            }
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();

            _isCrouching = true;
            Player.CoreContainer.AnimatorSynchronizer.IsSynchronized = false;
        }

        public override void AnimationFinishedTrigger() => Player.CoreContainer.AnimatorSynchronizer.IsSynchronized = true;
    }
}
