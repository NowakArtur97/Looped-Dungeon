using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CoreComponent : MonoBehaviour
    {
        protected CoreContainer CoreContainer { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = transform.parent.GetComponent<CoreContainer>();

            if (CoreContainer == null) { Debug.LogError("There is no Core on the parent"); }
        }
    }
}
