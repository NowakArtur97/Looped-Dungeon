using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CollisionSenses : CoreComponent
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 2f;
        [SerializeField] private LayerMask _whatIsGround;

        // TODO: CollisionSenses: Remove GET?
        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(_groundCheck, CoreContainer.transform.name);
            private set => _groundCheck = value;
        }

        public bool Grounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
    }
}
