using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyIdleState : GroundedState
    {
        private int _currentNumberOfIdleCycles;
        private Enemy _enemy;

        public EnemyIdleState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();

            _currentNumberOfIdleCycles = 0;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_currentNumberOfIdleCycles >= _enemy.EnemyData.numberOfIdleCycles)
                {
                    Debug.Log("Enter Move");
                }
            }
        }

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            _currentNumberOfIdleCycles++;
        }
    }
}

