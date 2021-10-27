namespace NowakArtur97.LoopedDungeon.Core
{
    public class WeaponCoreContrainer : BaseCore
    {
        private AnimationToWeapon _animationToWeapon;

        public AnimationToWeapon AnimationToWeapon
        {
            get => GenericNotImplementedError<AnimationToWeapon>.TryGet(_animationToWeapon, transform.parent.name);
            private set => _animationToWeapon = value;
        }

        private AnimatorSynchronizer _animatorSynchronizer;

        public AnimatorSynchronizer AnimatorSynchronizer
        {
            get => GenericNotImplementedError<AnimatorSynchronizer>.TryGet(_animatorSynchronizer, transform.parent.name);
            private set => _animatorSynchronizer = value;
        }

        protected override void Awake()
        {
            base.Awake();

            AnimationToWeapon = GetComponentInChildren<AnimationToWeapon>();
            AnimatorSynchronizer = GetComponentInChildren<AnimatorSynchronizer>();
            Inventory = GetComponentInParent<Inventory>();
        }
    }
}
