using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Rewind
{
    public class RewindDataHolder : MonoBehaviour
    {
        [SerializeField] private D_Rewind _rewindData;
        public D_Rewind RewindData
        {
            get => _rewindData;
            private set => _rewindData = value;
        }
    }
}
