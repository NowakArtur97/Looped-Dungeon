using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CloseRangeAbility : IAbility
    {
        private D_ThrowableWeapon _throwableWeaponData;
        private List<IDamagable> _toDamage = new List<IDamagable>();
        private float _damageAmount;

        public void InitAbility(Weapon weapon)
        {
            if (weapon.Data.GetType() == typeof(D_ThrowableWeapon))
            {
                _throwableWeaponData = (D_ThrowableWeapon)weapon.Data;
                _damageAmount = _throwableWeaponData.damageAmount;
            }
        }

        public void UseAbility(Weapon weapon)
        {
            _toDamage.ForEach(damagable => damagable.Damage(_damageAmount));
        }

        public void DetectTarget(Collider2D collision)
        {
            IDamagable damagable = collision.gameObject.GetComponentInChildren<IDamagable>();

            if (damagable != null && !_toDamage.Contains(damagable))
            {
                _toDamage.Add(damagable);
            }
        }

        public void IgnoreTarget(Collider2D collision)
        {
            IDamagable damagable = collision.gameObject.GetComponentInChildren<IDamagable>();

            if (damagable != null && _toDamage.Contains(damagable))
            {
                _toDamage.Remove(damagable);
            }
        }
    }
}
