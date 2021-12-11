namespace NowakArtur97.LoopedDungeon.Core
{
    public class EntityStats
    {
        private float _currentHealth;

        private readonly float _maxDamageResistance;
        private float _currentResistance;

        public EntityStats(D_Entity data)
        {
            _currentHealth = data.maxHealth;
            _currentResistance = data.maxDamageResistance;
            _maxDamageResistance = data.maxDamageResistance;
        }

        public bool IsDead() => _currentHealth <= 0;

        public bool IsResistanceNegative() => _currentResistance <= 0;

        public bool IsHurt() => _currentResistance < _maxDamageResistance;

        public void Damage(float damageAmount)
        {
            _currentHealth -= damageAmount;
            _currentResistance -= damageAmount;
        }

        public void ResetResistance() => _currentResistance = _maxDamageResistance;
    }
}
