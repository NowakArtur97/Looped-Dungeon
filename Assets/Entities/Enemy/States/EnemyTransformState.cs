using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyTransformState : State
    {
        private Mimic _mimic;

        public EnemyTransformState(Mimic entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _mimic = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();

            _mimic.GetComponentInChildren<SpriteRenderer>().sprite = _mimic.TransformSprite[Random.Range(0, _mimic.TransformSprite.Length)];
        }
    }
}
