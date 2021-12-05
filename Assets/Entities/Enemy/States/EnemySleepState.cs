using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemySleepState : EnemyGroundedState
    {
        private Stalker _stalker;
        private bool _isEnemyUnder;

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
                if (_isEnemyUnder)
                {
                    Entity.StateMachine.ChangeState(_stalker.StartFallingState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isEnemyUnder = Enemy.EnemyCoreContainer.CollisionSenses.IsEnemyUnder;
        }
    }
}
