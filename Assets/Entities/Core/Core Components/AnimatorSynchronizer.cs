using System;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AnimatorSynchronizer : CoreComponent
    {
        [SerializeField] private Animator _masterAnimator;
        [SerializeField] private Animator _childAnimator;

        public void Synchronize() => _childAnimator.Play(0, -1, _masterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
