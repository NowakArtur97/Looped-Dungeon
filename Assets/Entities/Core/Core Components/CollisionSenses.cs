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
        [SerializeField] private LayerMask _whatIsWall;

        // TODO: CollisionSenses: Remove GET?
        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(_groundCheck, CoreContainer.transform.name);
            private set => _groundCheck = value;
        }

        public bool Grounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

        public Transform WallCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(_wallCheck, CoreContainer.transform.name);
            private set => _wallCheck = value;
        }

        public bool Wall => Physics2D.OverlapCircle(_wallCheck.position, _wallCheckRadius, _whatIsGround);
    }
}
