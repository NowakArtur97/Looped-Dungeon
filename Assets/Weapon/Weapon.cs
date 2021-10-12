using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(Animator))]
    public class Weapon : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void EnterWeapon(string animationBoolName) => _animator.SetBool(animationBoolName, true);

        public void ExitWeapon(string animationBoolName) => _animator.SetBool(animationBoolName, false);
    }
}
