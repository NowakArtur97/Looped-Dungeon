using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class PlayerInputFrame
    {
        public readonly Vector2 MovementInput;
        public readonly bool JumpInput;
        public readonly bool MainAbilityInput;
        public readonly bool SecondaryAbilityInput;

        public PlayerInputFrame(Vector2 movementInput, bool jumpInput, bool mainAbilityInput, bool secondaryAbilityInput)
        {
            MovementInput = movementInput;
            JumpInput = jumpInput;
            MainAbilityInput = mainAbilityInput;
            SecondaryAbilityInput = secondaryAbilityInput;
        }
    }
}
