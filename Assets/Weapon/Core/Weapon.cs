using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected D_Weapon Data;

        protected WeaponCoreContrainer CoreContainer { get; private set; }

        protected virtual void Awake() => CoreContainer = GetComponentInChildren<WeaponCoreContrainer>();

        public void EnterWeapon(string animationBoolName) => CoreContainer.Animation.SetBoolVariable(animationBoolName, true);

        public void ExitWeapon(string animationBoolName) => CoreContainer.Animation.SetBoolVariable(animationBoolName, false);

        protected abstract void UseWeapon();

        public void SetCharacterVelocity(Vector2 velocity) => CoreContainer.Animation.SetVelocityVariable(velocity.x, velocity.y);

        public virtual void AnimationActionTrigger() { }
    }
}
