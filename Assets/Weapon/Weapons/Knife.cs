namespace NowakArtur97.LoopedDungeon.Core
{
    public class Knife : ThrowableWeapon
    {
        private ThrowAbility _mainAbility;

        protected override void InitializeAbilities()
        {
            _mainAbility = new ThrowAbility();
            MainAbility = _mainAbility;
        }
    }
}
