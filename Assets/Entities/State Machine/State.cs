using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;

        protected bool IsExitingState { get; private set; }
        protected bool IsAnimationFinished { get; private set; }
        public float StateEnterTime { get; private set; }
        private string _animationBoolName;

        public State(Entity entity, string animationBoolName)
        {
            Entity = entity;
            _animationBoolName = animationBoolName;
        }

        public virtual void Enter()
        {
            IsExitingState = false;
            IsAnimationFinished = false;
            StateEnterTime = Time.time;

            Entity.CoreContainer.AnimationToStateMachine.CurrentState = this;

            Entity.CoreContainer.Inventory?.Weapons.ForEach(weapon => weapon.InitWeapon(_animationBoolName, true));

            Entity.CoreContainer.Animation.SetBoolVariable(_animationBoolName, true);

            DoChecks();
        }

        public virtual void LogicUpdate()
        {
            if (Entity.EntityStats.IsDead())
            {
                Entity.StateMachine.ChangeState(Entity.DeadState);
            }
            if (Entity.EntityStats.IsResistanceNegative())
            {
                Entity.EntityStats.ResetResistance();
                Entity.StateMachine.ChangeState(Entity.HurtState);
            }
            //if (Entity.EntityStats.IsHurt() && Entity.HurtState.StateEnterTime + Entity.Data.damageResistanceResetTime <= Time.time)
            //{
            //    Debug.Log("ResetResistance");
            //    Entity.EntityStats.ResetResistance();
            //}
        }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void Exit()
        {
            Entity.CoreContainer.Animation.SetBoolVariable(_animationBoolName, false);

            Entity.CoreContainer.Inventory?.Weapons.ForEach(weapon => weapon.InitWeapon(_animationBoolName, false));

            IsExitingState = true;
        }

        public virtual void DoChecks() { }

        public virtual void AnimationFinishedTrigger() => IsAnimationFinished = true;
        public virtual void AnimationTrigger() { }
    }
}
