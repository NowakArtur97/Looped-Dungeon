using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private D_Projectile _data;
        public D_Projectile Data
        {
            get => _data;
            private set => _data = value;
        }

        private BaseCoreContainer _coreContainer;
        private bool _isTouchingWall;
        private GameObject _colidedEnemy;

        protected virtual void Awake() => _coreContainer = GetComponentInChildren<BaseCoreContainer>();

        private void Update()
        {
            // TODO: Projectile: Weapon: Enemy Move State: rb.angularVelocity = 0; rb.gravityScale = 0; in Awake instead of setting every frame
            _coreContainer.Movement.SetVelocityX(_coreContainer.Movement.FacingDirection * _data.moveSpeed);
        }

        private void FixedUpdate() => DoChecks();

        private void DoChecks()
        {
            _isTouchingWall = _coreContainer.CollisionSenses.IsTouchingWall;
            _colidedEnemy = _coreContainer.CollisionSenses.ColidedEnemy?.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamagable toDamage = collision.gameObject.GetComponentInChildren<IDamagable>();
            if (toDamage != null)
            {
                toDamage.Damage(_data.damageAmount);
            }

            Destroy(gameObject);
        }

        public void CheckIfShouldFlip(int facingDirection) => _coreContainer.Movement.CheckIfShouldFlip(facingDirection);
    }
}
