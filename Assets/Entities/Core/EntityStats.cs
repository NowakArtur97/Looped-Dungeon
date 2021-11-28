namespace NowakArtur97.LoopedDungeon.Core
{
    public class EntityStats
    {
        private float _currentHealth;

        public EntityStats(D_Entity data)
        {
            _currentHealth = data.maxHealth;
        }

        public bool IsAlive() => _currentHealth > 0;

        public void Damage(float damageAmount) => _currentHealth -= damageAmount;
    }
}
