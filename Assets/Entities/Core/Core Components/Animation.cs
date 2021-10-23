using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(Animator))]
    public class Animation : CoreComponent
    {
        public static class AbilityState
        {
            public static string MAIN = "mainAbility";
            public static string SECONDARY = "secondaryAbility";
        }
        private readonly string VELOCITY_X = "velocityX";
        private readonly string VELOCITY_Y = "velocityY";
        private readonly string NUMBER_OF_WEAPONS = "numberOfWeapons";

        private Animator _animator;

        protected override void Awake()
        {
            base.Awake();

            _animator = GetComponent<Animator>();
        }

        public void SetBoolVariable(string animationBoolName, bool value) => _animator.SetBool(animationBoolName, value);

        public void SetVelocityVariable(float x, float y)
        {
            _animator.SetFloat(VELOCITY_X, x);
            _animator.SetFloat(VELOCITY_Y, y);
        }

        public void SetNumberOfWeaponsVariable(int numberOfWeapons) => _animator.SetInteger(NUMBER_OF_WEAPONS, numberOfWeapons);
    }
}
