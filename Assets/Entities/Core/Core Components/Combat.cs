using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Combat : CoreComponent, IDamagable
    {
        private EntityStats _entityStats;

        public void Damage(float damageAmount)
        {
            // TODO: Combat: Spawn particle effect
            // TODO: Combat: If dead change to dead state
            // TODO: Combat: From time to time change to Hurt state
            Debug.Log(damageAmount);
            _entityStats.Damage(damageAmount);
        }

        public void InitEntityStats(EntityStats entityStats) => _entityStats = entityStats;
    }
}
