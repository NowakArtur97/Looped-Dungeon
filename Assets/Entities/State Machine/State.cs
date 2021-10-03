using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;

        protected bool IsExitingState;
        private string _animationBoolName;

        public State(Entity entity, string animationBoolName)
        {
            Entity = entity;
            _animationBoolName = animationBoolName;
        }

        public virtual void Enter()
        {
            IsExitingState = false;

            DoChecks();

            Entity.CoreContainer.Animator.SetBool(_animationBoolName, true);
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void Exit()
        {
            Entity.CoreContainer.Animator.SetBool(_animationBoolName, false);

            IsExitingState = true;
        }

        public virtual void DoChecks() { }
    }
}
