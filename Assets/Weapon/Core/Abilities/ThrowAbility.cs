using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class ThrowAbility : IAbility
    {
        private D_ThrowableWeapon _data;

        public void UseAbility(Weapon weapon)
        {
            if (weapon.Data.GetType() == typeof(D_ThrowableWeapon))
            {
                _data = (D_ThrowableWeapon)weapon.Data;
            }

            weapon.CoreContainer.Movement.SetVelocityX(weapon.CoreContainer.Movement.FacingDirection * _data.thrownSpeed);

            SetupThrowableLayer(weapon);
        }

        private void SetupThrowableLayer(Weapon weapon)
        {
            int throwableLayer = LayerMask.NameToLayer(_data.throwableLayerName);
            weapon.gameObject.layer = throwableLayer;
            foreach (Transform child in weapon.gameObject.transform.GetComponentsInChildren<Transform>())
            {
                child.gameObject.layer = throwableLayer;
            }
        }
    }
}
