using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_ThrowableData", menuName = "Data/Throwable Weapon")]
    public class D_ThrowableWeapon : D_Weapon
    {
        public string throwableLayerName = "Throwable";
        public float thrownSpeed = 10;
    }
}
