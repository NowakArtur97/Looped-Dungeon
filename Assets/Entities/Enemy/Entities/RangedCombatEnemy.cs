using NowakArtur97.LoopedDungeon.StateMachine;
using NowakArtur97.LoopedDungeon.Util;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class RangedCombatEnemy : Enemy
    {
        [SerializeField] private GameObject _projectile;
        public GameObject Projectile
        {
            get => _projectile;
            private set => _projectile = value;
        }
        [SerializeField] private Transform _projectileSpawnPosition;
        public Transform ProjectileSpawnPosition
        {
            get => GenericUtil<Transform>.GetOrDefault(_projectileSpawnPosition, CoreContainer.transform.name);
            private set => _projectileSpawnPosition = value;
        }
        [SerializeField] private float _backOffVelocity = 2;
        public float BackOffVelocity { get => _backOffVelocity; private set => _backOffVelocity = value; }
        [SerializeField] private float _backOffTime = 2;
        public float BackOffTime { get => _backOffTime; private set => _backOffTime = value; }

        public EnemyRangedAttackState RangedAttackState { get; private set; }
        public EnemyBackOffState BackOffState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new RangedCombatEnemyPlayerDetectedState(this, "playerDetected");
            RangedAttackState = new EnemyRangedAttackState(this, "rangedAttack");
            BackOffState = new EnemyBackOffState(this, "backOff");
        }
    }
}
