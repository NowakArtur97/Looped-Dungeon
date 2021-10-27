using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Sword : ThrowableWeapon
    {
        private CloseRangeAbility _mainAbility;
        private ThrowAbility _secondaryAbility;

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
