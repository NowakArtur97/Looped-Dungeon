using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Sword : ThrowableWeapon
    {
        private CloseRangeAbility _mainAbility;
        private ThrowAbility _secondaryAbility;

        public override void InitWeapon(string animationBoolName, bool value)
        {
            base.InitWeapon(animationBoolName, value);

            if (animationBoolName.Equals(Animation.AbilityState.SECONDARY))
            {
                WasThrown = true;
            }
        }

        protected override void InitializeAbilities()
        {
            _mainAbility = new CloseRangeAbility();
            _secondaryAbility = new ThrowAbility();
            MainAbility = _mainAbility;
            SecondaryAbility = _secondaryAbility;
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            _mainAbility.DetectTarget(collision);
        }

        public override void OnTriggerExit2D(Collider2D collision)
        {
            base.OnTriggerExit2D(collision);

            _mainAbility.IgnoreTarget(collision);
        }
    }
}
