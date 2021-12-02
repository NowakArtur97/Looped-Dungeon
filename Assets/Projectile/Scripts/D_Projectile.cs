using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_ProjectileData", menuName = "Data/Projectile")]
    public class D_Projectile : ScriptableObject
    {
        public float moveSpeed = 10;
        public float damageAmount = 6;
    }
}
