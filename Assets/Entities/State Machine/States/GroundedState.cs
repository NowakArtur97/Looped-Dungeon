using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class GroundedState : State
    {
        protected bool IsGrounded { get; private set; }
        protected bool IsGroundedBehind { get; private set; }
        protected bool IsCloseToWall { get; private set; }
        protected bool IsCloseToWallBehind { get; private set; }

        public GroundedState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = Entity.CoreContainer.CollisionSenses.IsGrounded;
            IsGroundedBehind = Entity.CoreContainer.CollisionSenses.IsGroundedBehind;
            IsCloseToWall = Entity.CoreContainer.CollisionSenses.IsCloseToWall;
            IsCloseToWallBehind = Entity.CoreContainer.CollisionSenses.IsCloseToWallBehind;
        }
    }
}
