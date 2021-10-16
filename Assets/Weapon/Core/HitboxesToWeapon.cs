using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class HitboxesToWeapon : MonoBehaviour
    {
        private AggressiveWeapon _weapon;

        private void Awake() => _weapon = transform.parent.parent.GetComponent<AggressiveWeapon>();

        private void OnTriggerEnter2D(Collider2D collision) => _weapon.DetectTarget(collision);

        private void OnTriggerExit2D(Collider2D collision) => _weapon.IgnoreTarget(collision);
    }
}
