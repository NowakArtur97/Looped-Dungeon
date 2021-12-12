using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Mimic : CloseCombatEnemy
    {
        [SerializeField] private Sprite[] _transformSprite;
        public Sprite[] TransformSprite
        {
            get => _transformSprite;
            private set => _transformSprite = value;

        }
        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseCombatBackingOffEnemyPlayerDetectedState(this, "playerDetected");
            HurtState = new RangedCombatEnemyHurtState(this, "hurt");
            BackOffState = new EnemyTransformingBackOffState(this, "backOff");
            TransformState = new EnemyTransformState(this, "transform");
        }
    }
}