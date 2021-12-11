using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class D_Entity : ScriptableObject
    {
        public float moveVelocity = 10;

        public float maxHealth = 30;

        public float maxDamageResistance = 15;
        public float damageResistanceResetTime = 10;
    }
}
