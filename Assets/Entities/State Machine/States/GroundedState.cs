using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class GroundedState : State
    {
        public GroundedState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }
    }
}
