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

        protected override void Awake()
        {
            base.Awake();

            _inputManager = GetComponent<PlayerInputManager>();
        }

        public void LogicUpdate()
        {
            MovementInput = _inputManager.MovementInput;
            JumpInput = _inputManager.JumpInput;
        }

        public void UseJumpInput() => _inputManager.UseJumpInput();
    }
}
