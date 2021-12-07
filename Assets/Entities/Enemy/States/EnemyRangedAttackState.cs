using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyRangedAttackState : EnemyAttackState
    {
        public EnemyRangedAttackState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void TriggerAttack() => SpawnProjectile();

        private void SpawnProjectile()
        {
            GameObject projectile = GameObject.Instantiate(Enemy.RangedCombatEnemyData.projectile, Enemy.transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().CheckIfShouldFlip(Entity.CoreContainer.Movement.FacingDirection);
        }
    }
}
