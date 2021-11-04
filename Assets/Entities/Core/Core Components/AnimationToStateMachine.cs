using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public State CurrentState;

        public void AnimationFinishedTrigger() => CurrentState.AnimationFinishedTrigger();

        public void AnimationTrigger() => CurrentState.AnimationTrigger();
    }
}
