using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class HurtState : State
    {
        public HurtState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
        }
    }
}
