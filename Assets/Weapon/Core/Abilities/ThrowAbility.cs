namespace NowakArtur97.LoopedDungeon.Core
{
    public class ThrowAbility : IAbility
    {
        public void UseAbility(Weapon weapon)
        {
            weapon.FreezeState();
            // TODO: ThrowAbility: Move to data
            weapon.CoreContainer.Movement.SetVelocityX(weapon.CoreContainer.Movement.FacingDirection * 10);
        }
    }
}
