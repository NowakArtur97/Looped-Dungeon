using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(Animator))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected D_Weapon Data;

        private readonly string VELOCITY_X = "velocityX";
        private readonly string VELOCITY_Y = "velocityY";

        private Animator _animator;

        protected virtual void Awake() => _animator = GetComponent<Animator>();

        public void EnterWeapon(string animationBoolName) => _animator.SetBool(animationBoolName, true);

        public void ExitWeapon(string animationBoolName) => _animator.SetBool(animationBoolName, false);

        public abstract void UseWeapon();

        // TODO: Weapon: Use methods from Animation Core Component(?)
        public void SetCharacterVelocity(Vector2 velocity)
        {
            _animator.SetFloat(VELOCITY_X, velocity.x);
            _animator.SetFloat(VELOCITY_Y, velocity.y);
        }
    }
}
