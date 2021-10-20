using System.Collections.Generic;
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

        public virtual void InitWeapon(string animationBoolName, bool value) => CoreContainer.Animation.SetBoolVariable(animationBoolName, value);

        protected virtual void FixedUpdate() => DoChecks();

        protected virtual void DoChecks() { }

        protected abstract void InitializeAbilities();

        public virtual void AnimationMainAbilityTrigger() => MainAbility.UseAbility(this);

        public virtual void AnimationSecondaryAbilityTrigger() => SecondaryAbility.UseAbility(this);

        public virtual void OnTriggerEnter2D(Collider2D collision) { }

        public virtual void OnTriggerExit2D(Collider2D collision) { }

        protected bool IsAbilityState(string animationBoolName) => CoreContainer.Animation.AbilityVariables.Contains(animationBoolName);
    }
}
