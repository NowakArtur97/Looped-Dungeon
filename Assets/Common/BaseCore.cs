using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class BaseCore : MonoBehaviour
    {
        private CollisionSenses _collisionSenses;

        public CollisionSenses CollisionSenses
        {
            get => GenericNotImplementedError<CollisionSenses>.TryGet(_collisionSenses, transform.parent.name);
            private set => _collisionSenses = value;
        }

        private Movement _movement;

        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(_movement, transform.parent.name);
            private set => _movement = value;
        }

        private Animation _animation;

        public Animation Animation
        {
            get => GenericNotImplementedError<Animation>.TryGet(_animation, transform.parent.name);
            private set => _animation = value;
        }

        protected virtual void Awake()
        {
            Animation = GetComponentInChildren<Animation>();
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
        }

        public virtual void LogicUpdate()
        {
            Movement.LogicUpdate();
            Animation.LogicUpdate();
        }
    }
}
