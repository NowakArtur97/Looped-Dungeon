using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Movement : CoreComponent
    {
        private Rigidbody2D _myRigidbody;
        private Vector2 _workspace;

        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _myRigidbody = transform.parent.parent.GetComponentInParent<Rigidbody2D>();

            FacingDirection = 1;
        }

        private void Update() => CurrentVelocity = _myRigidbody.velocity;

        public void DisableGravityScale() => _myRigidbody.gravityScale = 0;

        public void ResetGravityScale() => _myRigidbody.gravityScale = 1;

        public void SetVelocityZero()
        {
            _workspace.Set(0, 0);
            SetFinalVelocity();
        }

        public void SetVelocityX(float velocityX)
        {
            _workspace.Set(velocityX, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocityY)
        {
            _workspace.Set(CurrentVelocity.x, velocityY);
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            _myRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }

        public void CheckIfShouldFlip(int xInput)
        {
            if (ShouldFlip(xInput))
            {
                Flip();
            }
        }

        public void CheckIfShouldFlipWithoutRotating(int xInput)
        {
            if (ShouldFlip(xInput))
            {
                FlipWithoutRotation();
            }
        }

        public void Flip()
        {
            FacingDirection *= -1;
            _myRigidbody.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        private bool ShouldFlip(int xInput) => xInput != 0 && xInput != FacingDirection;

        private void FlipWithoutRotation() => FacingDirection *= -1;
    }
}
