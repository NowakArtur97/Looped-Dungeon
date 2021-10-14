using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AnimatorSynchronizer : MonoBehaviour
    {
        [SerializeField] private Animator _masterAnimator;
        [SerializeField] private Animator _childAnimator;

        private void Update() => _childAnimator.Play(0, -1, _masterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
