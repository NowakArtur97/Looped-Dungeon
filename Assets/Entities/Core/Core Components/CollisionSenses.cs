using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CollisionSenses : CoreComponent
    {
        [SerializeField] private Transform groundCheck;

        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(groundCheck, CoreContainer.transform.name);
            private set => groundCheck = value;
        }
    }
}
