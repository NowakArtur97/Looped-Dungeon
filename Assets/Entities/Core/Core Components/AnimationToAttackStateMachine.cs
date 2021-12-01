using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class AnimationToAttackStateMachine : MonoBehaviour
    {
        public EnemyAttackState EnemyAttackState;

        public void TriggerAttack() => EnemyAttackState.TriggerAttack();
    }
}
