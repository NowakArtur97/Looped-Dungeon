using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class HitboxesToEnemyAttackState : MonoBehaviour
    {
        public List<IDamagable> ToDamage { get; private set; }

        private void Awake() => ToDamage = new List<IDamagable>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamagable damagable = collision.gameObject.GetComponentInChildren<IDamagable>();

            if (damagable != null && !ToDamage.Contains(damagable))
            {
                ToDamage.Add(damagable);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IDamagable damagable = collision.gameObject.GetComponentInChildren<IDamagable>();

            if (damagable != null && ToDamage.Contains(damagable))
            {
                ToDamage.Remove(damagable);
            }
        }
    }
}
