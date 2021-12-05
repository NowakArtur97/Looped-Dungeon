using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemySleepState : EnemyGroundedState
    {
        private bool _isEnemyUnder;

        public EnemySleepState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.DisableGravityScale();
        }

        public override void Exit()
        {
            base.Exit();

            Entity.CoreContainer.Movement.ResetGravityScale();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_isEnemyUnder)
                {
                    Debug.Log("FALL STATE");
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
