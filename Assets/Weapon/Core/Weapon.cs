using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private D_Weapon _data;
        public D_Weapon Data
        {
            get => _data;
            private set => _data = value;
        }
        public IAbility MainAbility { get; protected set; }
        public IAbility SecondaryAbility { get; protected set; }

        public WeaponCoreContrainer CoreContainer { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = GetComponentInChildren<WeaponCoreContrainer>();

            InitializeAbilities();
        }

        public void EnterWeapon(string animationBoolName) =>
            CoreContainer.Animation.SetBoolVariable(animationBoolName, true);

        public void ExitWeapon(string animationBoolName) =>
            CoreContainer.Animation.SetBoolVariable(animationBoolName, false);

        private void UseMainAbility() => MainAbility.UseAbility(this);

        private void UseSecondaryAbility() => SecondaryAbility.UseAbility(this);

        protected abstract void InitializeAbilities();

        public virtual void AnimationMainAbilityTrigger() => UseMainAbility();

        public virtual void AnimationSecondaryAbilityTrigger() => UseSecondaryAbility();

        public virtual void OnTriggerEnter2D(Collider2D collision) { }

        public virtual void OnTriggerExit2D(Collider2D collision) { }
    }
}
