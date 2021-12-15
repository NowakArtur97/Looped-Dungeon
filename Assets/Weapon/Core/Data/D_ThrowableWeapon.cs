using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_ThrowableData", menuName = "Data/Throwable Weapon")]
    public class D_ThrowableWeapon : D_Weapon
    {
        public float damageAmount = 10;
        public string throwableLayerName = "Throwable";
        public string platformLayerName = "Player Weapon Platform";
        public float thrownSpeed = 10;
    }
}
