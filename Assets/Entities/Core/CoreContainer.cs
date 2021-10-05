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

        private Animation _animation;

        public Animation Animation
        {
            get => GenericNotImplementedError<Animation>.TryGet(_animation, transform.parent.name);
            private set => _animation = value;
        }

        private AnimationToStateMachine _animationToStateMachine;

        public AnimationToStateMachine AnimationToStateMachine
        {
            get => GenericNotImplementedError<AnimationToStateMachine>.TryGet(_animationToStateMachine, transform.parent.name);
            private set => _animationToStateMachine = value;
        }

        private Input _input;

        public Input Input
        {
            get => GenericNotImplementedError<Input>.TryGet(_input, transform.parent.name);
            private set => _input = value;
        }

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            Animation = GetComponentInChildren<Animation>();
            Input = GetComponentInChildren<Input>();
            AnimationToStateMachine = GetComponentInChildren<AnimationToStateMachine>();
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
            Input?.LogicUpdate();
        }
    }
}
