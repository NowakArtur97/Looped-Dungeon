using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Tossable : CoreComponent, ITossable
    {
        [SerializeField] private float tossedVelocity = 10f;

        public void TossUp() => CoreContainer.Movement.SetVelocityY(tossedVelocity);
    }
}
