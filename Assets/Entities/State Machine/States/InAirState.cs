using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class InAirState : State
    {
        protected bool IsGrounded { get; private set; }
        protected bool IsTouchingWall { get; private set; }

        public InAirState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = Entity.CoreContainer.CollisionSenses.IsGrounded;
            IsTouchingWall = Entity.CoreContainer.CollisionSenses.IsCloseToWall;
        }
    }
}
