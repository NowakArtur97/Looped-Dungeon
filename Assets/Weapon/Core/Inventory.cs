using System.Collections.Generic;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Inventory : CoreComponent
    {
        private List<Weapon> _weapons;
        public Weapon CurrentWeapon { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
            CurrentWeapon = _weapons.Count > 0 ? _weapons[0] : null;
        }

        public void RemoveCurrentWeapon()
        {
            Weapon newWeapon = _weapons.Count > 1 ? _weapons[1] : null;
            if (CurrentWeapon)
            {
                CurrentWeapon.transform.parent = null;
                _weapons.Remove(CurrentWeapon);
            }
            CurrentWeapon = newWeapon;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CoreContainer.Animation.SetNumberOfWeaponsVariable(_weapons.Count);
        }
    }
}
