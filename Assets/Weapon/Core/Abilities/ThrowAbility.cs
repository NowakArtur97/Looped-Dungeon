using NowakArtur97.LoopedDungeon.Util;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class ThrowAbility : IAbility
    {
        private ThrowableWeapon _throwableWeapon;
        private float _thrownSpeed;

        public void InitAbility(Weapon weapon)
        {
            if (weapon is ThrowableWeapon)
            {
                _throwableWeapon = (ThrowableWeapon)weapon;
                _thrownSpeed = _throwableWeapon.ThrowableWeaponData.thrownSpeed;
            }
        }

        public void UseAbility(Weapon weapon)
        {
            weapon.CoreContainer.Movement.SetVelocityX(weapon.CoreContainer.Movement.FacingDirection * _thrownSpeed);

            LayerUtil.ChangeLayer(weapon.gameObject, _throwableWeapon.ThrowableWeaponData.throwableLayerName);

            weapon.CoreContainer.AnimatorSynchronizer.IsSynchronized = false;
        }
    }
}
