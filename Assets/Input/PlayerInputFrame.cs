using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class PlayerInputFrame
    {
        public readonly Vector2 MovementInput;
        public readonly bool JumpInput;
        public readonly float JumpInputStartTime;
        public readonly bool MainAbilityInput;
        public readonly bool SecondaryAbilityInput;

        public PlayerInputFrame(Vector2 movementInput, bool jumpInput, float jumpInputStartTime, bool mainAbilityInput, bool secondaryAbilityInput)
        {
            MovementInput = movementInput;
            JumpInput = jumpInput;
            JumpInputStartTime = jumpInputStartTime;
            MainAbilityInput = mainAbilityInput;
            SecondaryAbilityInput = secondaryAbilityInput;
        }
    }
}
