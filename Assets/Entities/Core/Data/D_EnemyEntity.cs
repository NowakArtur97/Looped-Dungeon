using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_Data", menuName = "Data/Enemy")]
    public class D_EnemyEntity : D_Entity
    {
        public int numberOfIdleCycles = 5;
        public float maxAgroRange = 5;
        public float minAgroRange = 2;
    }
}
