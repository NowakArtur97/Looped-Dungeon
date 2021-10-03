using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CoreContainer : MonoBehaviour
    {
        private Movement _movement;

        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(_movement, transform.parent.name);
            private set => _movement = value;
        }

        private CollisionSenses _collisionSenses;

        public CollisionSenses CollisionSenses
        {
            get => GenericNotImplementedError<CollisionSenses>.TryGet(_collisionSenses, transform.parent.name);
            private set => _collisionSenses = value;
        }

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
        }

        public void LogicUpdate() => Movement.LogicUpdate();
    }
}
