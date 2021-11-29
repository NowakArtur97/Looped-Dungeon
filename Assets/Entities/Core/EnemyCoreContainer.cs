using NowakArtur97.LoopedDungeon.Util;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class EnemyCoreContainer : BaseCore
    {
        private EnemySenses _enemySenses;

        public EnemySenses EnemySenses
        {
            get => GenericUtil<EnemySenses>.GetOrDefault(_enemySenses, transform.parent.name);
            private set => _enemySenses = value;
        }

        protected override void Awake()
        {
            base.Awake();

            _enemySenses = GetComponentInChildren<EnemySenses>();
        }
    }
}
