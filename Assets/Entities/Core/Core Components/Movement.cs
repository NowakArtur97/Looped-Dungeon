using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Movement : CoreComponent
    {
        private Rigidbody2D _myRigidbody;
        private Vector2 _workspace;

        public Vector2 CurrentVelocity { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _myRigidbody = GetComponentInParent<Rigidbody2D>();
        }

        public void LogicUpdate() => CurrentVelocity = _myRigidbody.velocity;
    }
}
