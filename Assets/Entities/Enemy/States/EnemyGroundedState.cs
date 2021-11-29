using System.Collections;
using System.Collections.Generic;
using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyGroundedState : GroundedState
    {
        private Enemy _enemy;
        protected bool IsPlayerInMinAgro { get; private set; }
        protected bool IsPlayerInMaxAgro { get; private set; }

        public EnemyGroundedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgro = _enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(_enemy.EnemyData.minAgroRange);
            IsPlayerInMinAgro = _enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(_enemy.EnemyData.maxAgroRange);
        }
    }
}
