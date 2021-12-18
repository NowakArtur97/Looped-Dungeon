using NowakArtur97.LoopedDungeon.Util;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class BaseCoreContainer : MonoBehaviour
    {
        private CollisionSenses _collisionSenses;

        public CollisionSenses CollisionSenses
        {
            get => GenericUtil<CollisionSenses>.GetOrDefault(_collisionSenses, transform.parent.name);
            private set => _collisionSenses = value;
        }

        private Movement _movement;

        public Movement Movement
        {
            get => GenericUtil<Movement>.GetOrDefault(_movement, transform.parent.name);
            private set => _movement = value;
        }

        private Animation _animation;

        public Animation Animation
        {
            get => GenericUtil<Animation>.GetOrDefault(_animation, transform.parent.name);
            private set => _animation = value;
        }

        private AnimatorSynchronizer _animatorSynchronizer;

        public AnimatorSynchronizer AnimatorSynchronizer
        {
            get => GenericUtil<AnimatorSynchronizer>.GetOrDefault(_animatorSynchronizer, transform.parent.name);
            private set => _animatorSynchronizer = value;
        }

        private AnimationToStateMachine _animationToStateMachine;

        public AnimationToStateMachine AnimationToStateMachine
        {
            get => GenericUtil<AnimationToStateMachine>.GetOrDefault(_animationToStateMachine, transform.parent.name);
            private set => _animationToStateMachine = value;
        }

        private Inventory _inventory;

        public Inventory Inventory
        {
            get => GenericUtil<Inventory>.GetOrDefault(_inventory, transform.parent.name);
            protected set => _inventory = value;
        }

        private Combat _combat;

        public Combat Combat
        {
            get => GenericUtil<Combat>.GetOrDefault(_combat, transform.parent.name);
            protected set => _combat = value;
        }

        protected virtual void Awake()
        {
            Animation = GetComponentInChildren<Animation>();
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            AnimationToStateMachine = GetComponentInChildren<AnimationToStateMachine>();
            AnimatorSynchronizer = GetComponentInChildren<AnimatorSynchronizer>();
            Inventory = GetComponentInChildren<Inventory>();
            Combat = GetComponentInChildren<Combat>();
        }
    }
}
