namespace NowakArtur97.LoopedDungeon.Core
{
    public class Shield : Weapon
    {
        private TossUpAbility _mainAbility;

        protected override void InitializeAbilities()
        {
            _mainAbility = new TossUpAbility();
            MainAbility = _mainAbility;
        }
    }
}
