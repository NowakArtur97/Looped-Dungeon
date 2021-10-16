using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class BaseCore : MonoBehaviour
    {
        private Animation _animation;

        public Animation Animation
        {
            get => GenericNotImplementedError<Animation>.TryGet(_animation, transform.parent.name);
            private set => _animation = value;
        }

        protected virtual void Awake() => Animation = GetComponentInChildren<Animation>();
    }
}
