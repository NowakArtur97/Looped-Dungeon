using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AggressiveWeapon : Weapon
    {
        private List<IDamagable> _toDamage;

        protected override void Awake()
        {
            base.Awake();

            _toDamage = new List<IDamagable>();
        }

        protected override void UseWeapon()
        {
            _toDamage.ForEach(damagable =>
            {
                damagable.Damage(Data.damageAmount);
            });
        }

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

        public override void AnimationActionTrigger()
        {
            base.AnimationActionTrigger();

            UseWeapon();
        }
    }
}
