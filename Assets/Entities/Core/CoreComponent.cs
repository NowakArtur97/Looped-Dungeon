using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CoreComponent : MonoBehaviour
    {
        protected BaseCoreContainer CoreContainer { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = transform.parent.GetComponent<BaseCoreContainer>();

            if (CoreContainer == null)
            {
                Debug.LogError("There is no Core on the parent");
            }
        }
    }
}
