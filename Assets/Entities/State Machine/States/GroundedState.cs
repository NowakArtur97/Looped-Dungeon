using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class GroundedState : State
    {
        private bool isGrounded;

        public GroundedState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = Entity.CoreContainer.CollisionSenses.Grounded;
        }
    }
}
