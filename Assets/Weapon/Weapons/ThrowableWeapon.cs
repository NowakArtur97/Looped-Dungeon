namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class ThrowableWeapon : Weapon
    {
        private bool _isTouchingWall;
        private bool _isThrown;
        private bool _hasStopped;

        public override void InitWeapon(string animationBoolName, bool value)
        {
            if (_isThrown)
            {
                return;
            }

            if (IsAbilityState(animationBoolName))
            {
                _isThrown = true;
            }

            base.InitWeapon(animationBoolName, value);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (_isTouchingWall && !_hasStopped)
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
