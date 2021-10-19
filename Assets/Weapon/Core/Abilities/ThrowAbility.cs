namespace NowakArtur97.LoopedDungeon.Core
{
    public class ThrowAbility : IAbility
    {
        public void UseAbility(Weapon weapon)
        {
            // TODO: ThrowAbility: Move to data
            weapon.CoreContainer.Movement.SetVelocityX(weapon.CoreContainer.Movement.FacingDirection * 10);
        }
    }
}
