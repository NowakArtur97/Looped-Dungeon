using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class ThrowAbility : IAbility
    {
        private D_ThrowableWeapon _throwableWeaponData;

        public void UseAbility(Weapon weapon)
        {
            if (weapon.Data.GetType() == typeof(D_ThrowableWeapon))
            {
                _throwableWeaponData = (D_ThrowableWeapon)weapon.Data;
            }

            weapon.CoreContainer.Movement.SetVelocityX(weapon.CoreContainer.Movement.FacingDirection * _throwableWeaponData.thrownSpeed);

            SetupThrowableLayer(weapon);
        }

        private void SetupThrowableLayer(Weapon weapon)
        {
            int throwableLayer = LayerMask.NameToLayer(_throwableWeaponData.throwableLayerName);
            weapon.gameObject.layer = throwableLayer;
            foreach (Transform child in weapon.gameObject.transform.GetComponentsInChildren<Transform>())
            {
                child.gameObject.layer = throwableLayer;
            }
        }
    }
}
