using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(Animator))]
    public class Weapon : MonoBehaviour
    {
        private readonly string VELOCITY_X = "velocityX";
        private readonly string VELOCITY_Y = "velocityY";

        public Animator Animator;

        private void Awake() => Animator = GetComponent<Animator>();

        public void EnterWeapon(string animationBoolName) => Animator.SetBool(animationBoolName, true);

        public void ExitWeapon(string animationBoolName) => Animator.SetBool(animationBoolName, false);

        // TODO: Weapon: Use methods from Animation Core Component(?)
        public void SetCharacterVelocity(Vector2 velocity)
        {
            Animator.SetFloat(VELOCITY_X, velocity.x);
            Animator.SetFloat(VELOCITY_Y, velocity.y);
        }
    }
}
