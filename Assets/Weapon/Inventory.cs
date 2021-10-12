using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Inventory : MonoBehaviour
    {
        private Weapon[] _weapons;
        public Weapon CurrentWeapon { get; private set; }

        private void Start()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            CurrentWeapon = _weapons[0];
        }
    }
}
