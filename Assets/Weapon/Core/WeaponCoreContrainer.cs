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

        protected override void Awake()
        {
            base.Awake();

            AnimationToWeapon = GetComponentInChildren<AnimationToWeapon>();
        }
    }
}
