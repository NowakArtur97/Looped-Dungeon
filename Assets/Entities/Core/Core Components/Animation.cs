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

        public void SetVelocityVariable()
        {
            _animator.SetFloat(VELOCITY_X, Mathf.Abs(CoreContainer.Input.MovementInput.x));
            _animator.SetFloat(VELOCITY_Y, CoreContainer.Movement.CurrentVelocity.y);
        }

        // TODO: Animation: Move to separate script
        private void Update()
        {
            _animator.Play(0, -1, CoreContainer.Inventory.CurrentWeapon.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
}
