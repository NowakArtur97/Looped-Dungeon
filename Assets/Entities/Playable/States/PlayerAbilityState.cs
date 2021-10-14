using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class PlayerAbilityState : AbilityState
    {
        protected Player Player { get; private set; }

        public PlayerAbilityState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            Player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsAbilityFinished)
                {
                    if (IsGrounded)
                    {
                        Player.StateMachine.ChangeState(Player.IdleState);
                    }
                    else
                    {
                        Player.StateMachine.ChangeState(Player.InAirState);
                    }
                }
            }
        }
    }
}
