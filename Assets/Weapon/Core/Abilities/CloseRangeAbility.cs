using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CloseRangeAbility : IAbility
    {
        private List<IDamagable> _toDamage = new List<IDamagable>();

        public void UseAbility(Weapon weapon) => _toDamage.ForEach(damagable => damagable.Damage(weapon.Data.damageAmount));

        public void DetectTarget(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamagable damagable))
            {
                _toDamage.Add(damagable);
            }
        }

        public void IgnoreTarget(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamagable damagable))
            {
                _toDamage.Remove(damagable);
            }
        }
    }
}
