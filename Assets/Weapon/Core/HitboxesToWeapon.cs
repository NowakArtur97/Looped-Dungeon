using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class HitboxesToWeapon : MonoBehaviour
    {
        private Weapon _weapon;

        private void Awake() => _weapon = transform.parent.parent.GetComponent<Weapon>();

        private void OnTriggerEnter2D(Collider2D collision) => _weapon.OnTriggerEnter2D(collision);

        private void OnTriggerExit2D(Collider2D collision) => _weapon.OnTriggerExit2D(collision);
    }
}
