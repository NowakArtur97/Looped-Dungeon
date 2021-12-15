using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class TossUpAbility : IAbility
    {
        private List<ITossable> _tossable = new List<ITossable>();

        public void InitAbility(Weapon weapon) { }

        public void UseAbility(Weapon weapon) => _tossable.ForEach(damagable => damagable.TossUp());

        public void DetectTarget(Collider2D collision)
        {
            ITossable tossable = collision.GetComponentInChildren<ITossable>();
            if (tossable != null && !_tossable.Contains(tossable))
            {
                _tossable.Add(tossable);
            }
        }

        public void IgnoreTarget(Collider2D collision)
        {
            ITossable tossable = collision.GetComponentInChildren<ITossable>();
            if (tossable != null)
            {
                _tossable.Remove(tossable);
            }
        }
    }
}
