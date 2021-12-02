using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class CloseCombatEnemy : Enemy
    {
        [SerializeField] private float _meleeAttackDamage = 10;
        public float MeleeAttackDamage
        {
            get => _meleeAttackDamage;
            private set => _meleeAttackDamage = value;
        }

        public EnemyChargePlayerState ChargePlayerState { get; private set; }
        public EnemyMeleeAttackState MeleeAttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseCombatEnemyPlayerDetectedState(this, "playerDetected");
            ChargePlayerState = new EnemyChargePlayerState(this, "chargePlayer");
            MeleeAttackState = new EnemyMeleeAttackState(this, "meleeAttack");
        }
    }
}
