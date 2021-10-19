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
        protected bool IsStateFrozen { get; private set; }
        public IAbility MainAbility { get; protected set; }
        public IAbility SecondaryAbility { get; protected set; }
        protected void FreezeState() => IsStateFrozen = true;

        public WeaponCoreContrainer CoreContainer { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = GetComponentInChildren<WeaponCoreContrainer>();

            InitializeAbilities();
        }

        public void InitWeapon(string animationBoolName, bool value)
        {
            if (!IsStateFrozen)
            {
                CoreContainer.Animation.SetBoolVariable(animationBoolName, value);
            }
        }

        protected virtual void FixedUpdate() => DoChecks();

        protected virtual void DoChecks() { }

        private void UseMainAbility() => MainAbility.UseAbility(this);

        private void UseSecondaryAbility() => SecondaryAbility.UseAbility(this);

        protected abstract void InitializeAbilities();

        public virtual void AnimationMainAbilityTrigger() => UseMainAbility();

        public virtual void AnimationSecondaryAbilityTrigger() => UseSecondaryAbility();

        public virtual void OnTriggerEnter2D(Collider2D collision) { }

        public virtual void OnTriggerExit2D(Collider2D collision) { }
    }
}
