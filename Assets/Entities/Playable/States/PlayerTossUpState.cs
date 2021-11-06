using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerTossUpState : PlayerAbilityState
    {
        private bool _isCrouching;
        private bool _isStandingOn;

        public PlayerTossUpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Movement.SetVelocityX(0);
        }

        public override void Exit()
        {
            base.Exit();

            _isCrouching = false;
            _isStandingOn = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isCrouching && _isStandingOn)
            {
                Debug.Log("ABILITY");
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();

            _isCrouching = true;
        }
    }
}
