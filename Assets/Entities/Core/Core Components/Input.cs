using NowakArtur97.LoopedDungeon.Input;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Input : CoreComponent
    {
        private PlayerInputManager _inputManager;

        public Vector2 MovementInput { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _inputManager = GetComponentInChildren<PlayerInputManager>();
        }

        public void LogicUpdate()
        {
            MovementInput = _inputManager.MovementInput;
        }
    }
}
