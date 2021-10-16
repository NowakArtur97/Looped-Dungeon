namespace NowakArtur97.LoopedDungeon.Core
{
    public class Inventory : CoreComponent
    {
        private Weapon[] _weapons;
        public Weapon CurrentWeapon { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _weapons = GetComponentsInChildren<Weapon>();
            CurrentWeapon = _weapons[0];
        }
    }
}
