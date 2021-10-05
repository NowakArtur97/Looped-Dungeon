using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_Data", menuName = "Data/Entity")]
    public class D_Entity : ScriptableObject
    {
        public float moveVelocity = 10;
        public float jumpVelocity = 8;
    }
}
