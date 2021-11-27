using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class AbilityState : State
    {
        public bool IsAbilityFinished;

        protected bool IsGrounded { get; private set; }

        public AbilityState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            IsAbilityFinished = false;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = Entity.CoreContainer.CollisionSenses.IsGrounded;
        }
    }
}
