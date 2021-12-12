using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class EntityStats
    {
        private float _currentHealth;

        private readonly float _maxDamageResistance;
        private float _currentResistance;
        private float _lastResistanceResetTime;

        public EntityStats(D_Entity data)
        {
            _currentHealth = data.maxHealth;
            _currentResistance = data.maxDamageResistance;
            _maxDamageResistance = data.maxDamageResistance;
            _lastResistanceResetTime = Time.time;
        }

        public void Damage(float damageAmount)
        {
            _currentHealth -= damageAmount;
            _currentResistance -= damageAmount;
        }

        public bool IsDead() => _currentHealth <= 0;

        public void ResetResistance()
        {
            _currentResistance = _maxDamageResistance;
            _lastResistanceResetTime = Time.time;
        }

        public bool IsResistanceNegative() => _currentResistance <= 0;

        public bool IsTimeToResetResistance(float damageResistanceResetTime) => _lastResistanceResetTime + damageResistanceResetTime <= Time.time;
    }
}
