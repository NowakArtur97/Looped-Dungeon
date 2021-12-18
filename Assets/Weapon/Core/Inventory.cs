using System.Collections.Generic;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Inventory : CoreComponent
    {
        public List<Weapon> Weapons { get; private set; }
        public Weapon CurrentWeapon { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
            CurrentWeapon = Weapons.Count > 0 ? Weapons[0] : null;
        }

        public void RemoveCurrentWeapon()
        {
            Weapon newWeapon = Weapons.Count > 1 ? Weapons[1] : null;
            if (CurrentWeapon)
            {
                CurrentWeapon.transform.parent = null;
                Weapons.Remove(CurrentWeapon);
            }
            CurrentWeapon = newWeapon;
        }

        private void Update() => CoreContainer.Animation.SetNumberOfWeaponsVariable(Weapons.Count);
    }
}
