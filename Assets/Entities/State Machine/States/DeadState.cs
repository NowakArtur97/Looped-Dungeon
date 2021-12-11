using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class DeadState : State
    {
        public DeadState(Entity entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Animation.SetBattleMode(false);
        }
    }
}
