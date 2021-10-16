using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AnimationToWeapon : MonoBehaviour
    {
        private Weapon _weapon;

        private void Awake() => _weapon = transform.parent.parent.GetComponentInParent<Weapon>();

        public void AnimationActionTrigger() => _weapon.AnimationActionTrigger();
    }
}