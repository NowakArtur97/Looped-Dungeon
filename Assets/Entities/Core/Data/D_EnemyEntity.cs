using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_Data", menuName = "Data/Enemy")]
    public class D_EnemyEntity : D_Entity
    {
        public int numberOfIdleCycles = 5;
        public float maxAgroRange = 5;
        public float minAgroRange = 2;

        public float meleeAttackDamage = 10;
        public float rangedAttackDamage = 10;
    }
}
