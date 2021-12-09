using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_RangedCombatData", menuName = "Data/RangedCombatEnemy")]
    public class D_RangedCombatEnemyEntity : ScriptableObject
    {
        public GameObject projectile;
        public float backOffVelocity = 2;
        public float backOffTime = 2;
        public float timeToWaitBeforeRangedAttack = 2;
    }
}

