using NowakArtur97.LoopedDungeon.Util;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CollisionSenses : CoreComponent
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 2f;
        [SerializeField] private LayerMask _whatIsGround;

        [SerializeField] private Transform _wallCheck;
        [SerializeField] private float _wallCheckRadius = 2f;
        [SerializeField] private float _wallCheckDistance = 2f;
        [SerializeField] private LayerMask _whatIsWall;

        [SerializeField] private Transform _enemyCollisonCheck;
        [SerializeField] private float _enemyCollisonCheckRadius = 2f;
        [SerializeField] private LayerMask _whatIsEnemy;

        public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

        public bool IsTouchingWall => Physics2D.OverlapCircle(_wallCheck.position, _wallCheckRadius, _whatIsGround);
        public bool IsCloseToWall => Physics2D.Raycast(_wallCheck.position, transform.right, _wallCheckDistance, _whatIsGround);

        public Collider2D ColidedEnemy => Physics2D.OverlapCircle(_enemyCollisonCheck.position, _enemyCollisonCheckRadius, _whatIsEnemy);
    }
}
