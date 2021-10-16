using System;
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

        public void LogicUpdate() => CurrentVelocity = _myRigidbody.velocity;

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

        public void AddYForce(float velocity) => _myRigidbody.AddForce(transform.up * velocity);

        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            }
        }

        public void Flip()
        {
            FacingDirection *= -1;
            _myRigidbody.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
}
