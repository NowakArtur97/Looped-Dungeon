using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;

        protected bool IsExitingState;

        public State(Entity entity)
        {
            Entity = entity;
        }

        public virtual void Enter() => IsExitingState = false;

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void Exit() => IsExitingState = true;

        public virtual void DoChecks() { }
    }
}
