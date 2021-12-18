using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class PlayerInputFrame
    {
        public Vector2 MovementInput;
        public bool JumpInput;
        public float JumpInputStartTime;
        public bool MainAbilityInput;
        public bool SecondaryAbilityInput;

        public PlayerInputFrame(Vector2 movementInput, bool jumpInput, float jumpInputStartTime, bool mainAbilityInput, bool secondaryAbilityInput)
        {
            MovementInput = movementInput;
            JumpInput = jumpInput;
            JumpInputStartTime = jumpInputStartTime;
            MainAbilityInput = mainAbilityInput;
            SecondaryAbilityInput = secondaryAbilityInput;
        }

        public PlayerInputFrame Clone() => new PlayerInputFrame(MovementInput, JumpInput, JumpInputStartTime, MainAbilityInput, SecondaryAbilityInput);
    }
}
