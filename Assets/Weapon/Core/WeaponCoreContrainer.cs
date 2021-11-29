using NowakArtur97.LoopedDungeon.Util;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class WeaponCoreContrainer : BaseCore
    {
        private AnimationToWeapon _animationToWeapon;

        public AnimationToWeapon AnimationToWeapon
        {
            get => GenericUtil<AnimationToWeapon>.GetOrDefault(_animationToWeapon, transform.parent.name);
            private set => _animationToWeapon = value;
        }

        protected override void Awake()
        {
            base.Awake();

            AnimationToWeapon = GetComponentInChildren<AnimationToWeapon>();
            Inventory = GetComponentInParent<Inventory>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Animation.SetNumberOfWeaponsVariable(Inventory.Weapons.Count);
            AnimatorSynchronizer.LogicUpdate();
        }
    }
}
