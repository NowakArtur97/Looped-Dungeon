using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Shield : Weapon
    {
        [SerializeField] private GameObject _tossUpHitColliderGameObject;

        private TossUpAbility _secondaryAbility;

        protected override void InitializeAbilities()
        {
            _secondaryAbility = new TossUpAbility();
            SecondaryAbility = _secondaryAbility;
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            _secondaryAbility.DetectTarget(collision);
        }

        public override void OnTriggerExit2D(Collider2D collision)
        {
            base.OnTriggerExit2D(collision);

            _secondaryAbility.IgnoreTarget(collision);
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();

            _tossUpHitColliderGameObject.SetActive(!_tossUpHitColliderGameObject.activeSelf);
        }
    }
}
