using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    [CreateAssetMenu(fileName = "_RewindData", menuName = "Data/Rewind")]
    public class D_Rewind : ScriptableObject
    {
        public float rewindTime = 10f;
    }
}
