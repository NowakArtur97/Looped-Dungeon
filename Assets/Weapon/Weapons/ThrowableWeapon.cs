using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class ThrowableWeapon : Weapon
    {
        private bool _isTouchingWall;
        private bool _hasStopped;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (IsStateFrozen && _isTouchingWall && !_hasStopped)
            {
                _hasStopped = true;
                CoreContainer.Movement.SetVelocityZero();
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            _isTouchingWall = CoreContainer.CollisionSenses.Wall;
        }
    }
}
