using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class ThrowableWeapon : Weapon
    {
        [SerializeField] private AnimationAbilityState _throwBoolTrigger = AnimationAbilityState.mainAbility;
        private bool _isTouchingWall;
        protected bool WasThrown;
        private bool _hasStopped;

        public override void InitWeapon(string animationBoolName, bool value)
        {
            bool isAbilityAnimation = animationBoolName.Equals(_throwBoolTrigger.ToString());
            bool isCurrentWeapon = CoreContainer.Inventory.CurrentWeapon == this;

            if (WasThrown)
            {
                return;
            }

            base.InitWeapon(animationBoolName, value);

            if (isAbilityAnimation && isCurrentWeapon && value)
            {
                WasThrown = true;
            }
        }

        protected override void Update()
        {
            if (WasThrown)
            {
                return;
            }

            base.Update();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (WasThrown && _isTouchingWall && !_hasStopped)
            {
                _hasStopped = true;
                CoreContainer.Movement.SetVelocityZero();
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            _isTouchingWall = CoreContainer.CollisionSenses.WallCircle;
        }
    }
}
