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

            _animator = GetComponent<Animator>();
        }

        public void SetBoolVariable(string animationBoolName, bool value) => _animator.SetBool(animationBoolName, value);

        public void SetVelocityVariable(float x, float y)
        {
            _animator.SetFloat(VELOCITY_X, x);
            _animator.SetFloat(VELOCITY_Y, y);
        }
    }
}
