using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;

        protected bool IsExitingState { get; private set; }
        protected bool IsAnimationFinished { get; private set; }
        private string _animationBoolName;

        public State(Entity entity, string animationBoolName)
        {
            Entity = entity;
            _animationBoolName = animationBoolName;
        }

        public virtual void Enter()
        {
            IsExitingState = false;
            IsAnimationFinished = false;

            Entity.CoreContainer.AnimationToStateMachine.CurrentState = this;
            Entity.CoreContainer.Animation.SetBoolVariable(_animationBoolName, true);

            Entity.CoreContainer.Inventory.CurrentWeapon.EnterWeapon(_animationBoolName);

            DoChecks();
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void Exit()
        {
            Entity.CoreContainer.Animation.SetBoolVariable(_animationBoolName, false);

            Entity.CoreContainer.Inventory.CurrentWeapon.ExitWeapon(_animationBoolName);

            IsExitingState = true;
        }

        public virtual void DoChecks() { }

        public virtual void AnimationFinishedTrigger() => IsAnimationFinished = true;
    }
}
