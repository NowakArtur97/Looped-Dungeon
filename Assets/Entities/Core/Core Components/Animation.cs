using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(Animator))]
    public class Animation : CoreComponent
    {
        private readonly string VELOCITY_X = "velocityX";
        private readonly string VELOCITY_Y = "velocityY";

        private Animator _animator;

        protected override void Awake()
        {
            base.Awake();

            _animator = GetComponentInChildren<Animator>();
        }

        public void SetBoolVariable(string animationBoolName, bool value) => _animator.SetBool(animationBoolName, value);

        public void SetVelocityVariable()
        {
            Debug.Log(CoreContainer.Movement.CurrentVelocity);
            _animator.SetFloat(VELOCITY_X, CoreContainer.Movement.CurrentVelocity.x);
            _animator.SetFloat(VELOCITY_Y, CoreContainer.Movement.CurrentVelocity.y);

        }
    }
}
