using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemySleepState : State
    {
        private Stalker _stalker;
        private bool _isPlayerUnder;

        public EnemySleepState(Stalker entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _stalker = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.DisableGravityScale();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_isPlayerUnder)
                {
                    Entity.StateMachine.ChangeState(_stalker.StartFallingState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerUnder = _stalker.EnemyCoreContainer.EnemySenses.IsPlayerUnder;
        }
    }
}
