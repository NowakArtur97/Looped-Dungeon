using NowakArtur97.LoopedDungeon.Input;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class Input : CoreComponent
    {
        private PlayerInputManager _inputManager;

        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public float JumpInputStartTime { get; private set; }
        public bool MainAbilityInput { get; private set; }
        public bool SecondaryAbilityInput { get; private set; }

        public bool IsRecording;
        public bool StoppedRewinding;

        protected override void Awake()
        {
            base.Awake();

            _inputManager = GetComponent<PlayerInputManager>();
        }

        private void FixedUpdate()
        {
            if (IsRecording)
            {
                GetInputFromInputManager();
            }
            if (StoppedRewinding)
            {
                ResetInput();
            }
        }

        public void SetMovement(PlayerInputFrame inputFrame, float recordingStartTime)
        {
            float jumpInputStartTime = inputFrame.JumpInputStartTime + recordingStartTime;
            SetInput(inputFrame.MovementInput, inputFrame.JumpInput, jumpInputStartTime,
                inputFrame.MainAbilityInput, inputFrame.SecondaryAbilityInput);
            _inputManager.JumpInputStartTime = jumpInputStartTime;
        }

        private void GetInputFromInputManager() => SetInput(_inputManager.MovementInput, _inputManager.JumpInput, _inputManager.JumpInputStartTime,
            _inputManager.MainAbilityInput, _inputManager.SecondaryAbilityInput);

        private void ResetInput() => SetInput(Vector2.zero, false, 0, false, false);

        private void SetInput(Vector2 movementInput, bool jumpInput, float jumpInputStartTime, bool mainAbilityInput, bool secondaryAbilityInput)
        {
            MovementInput = movementInput;
            JumpInput = jumpInput;
            JumpInputStartTime = jumpInputStartTime;
            MainAbilityInput = mainAbilityInput;
            SecondaryAbilityInput = secondaryAbilityInput;
        }
    }
}
