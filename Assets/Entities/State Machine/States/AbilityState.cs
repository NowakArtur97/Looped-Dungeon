using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class AbilityState : State
    {
        public bool IsAbilityFinished;

        public AbilityState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            IsAbilityFinished = false;
        }
    }
}
