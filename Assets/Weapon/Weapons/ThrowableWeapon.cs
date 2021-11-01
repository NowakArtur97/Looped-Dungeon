using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class ThrowableWeapon : Weapon
    {
        private bool _isTouchingWall;
        protected bool WasThrown;
        private bool _hasStopped;
        [SerializeField] private AnimationAbilityState _throwBoolTrigger;

        public override void InitWeapon(string animationBoolName, bool value)
        {
            bool isAbilityAnimation = animationBoolName.Equals(_throwBoolTrigger.ToString());
            if (WasThrown || (CoreContainer.Inventory.CurrentWeapon != this && isAbilityAnimation))
            {
                return;
            }

            base.InitWeapon(animationBoolName, value);

            if (isAbilityAnimation)
            {
                Debug.Log(WasThrown);
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
