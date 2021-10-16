using UnityEngine;

// TODO: TempDamagable: Remove
namespace NowakArtur97.LoopedDungeon.Core
{
    public class TempDamagable : MonoBehaviour, IDamagable
    {
        public void Damage(float damageAmount)
        {
            Debug.Log("Damaged : " + damageAmount);
        }
    }
}
