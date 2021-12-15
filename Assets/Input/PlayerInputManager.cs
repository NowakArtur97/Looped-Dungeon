using UnityEngine;
using UnityEngine.InputSystem;

namespace NowakArtur97.LoopedDungeon.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputManager : MonoBehaviour
    {
        private readonly float _pressedButtonTime = 0.2f;

        private PlayerInput _playerInput;

        private Vector2 _workspace;

        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public float JumpInputStartTime;
        public bool MainAbilityInput { get; private set; }
        public bool SecondaryAbilityInput { get; private set; }

        private void Awake() => _playerInput = GetComponent<PlayerInput>();

        private void Update() => CheckJumpInput();

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            _workspace = context.ReadValue<Vector2>();
            _workspace.Set(Mathf.RoundToInt(_workspace.x), Mathf.RoundToInt(_workspace.y));
            MovementInput = _workspace;
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStartTime = Time.time;
            }
        }

        public void OnMainAbilityInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                MainAbilityInput = true;
            }
            if (context.canceled)
            {
                MainAbilityInput = false;
            }
        }

        public void OnSecondaryAbilityInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                SecondaryAbilityInput = true;
            }
            if (context.canceled)
            {
                SecondaryAbilityInput = false;
            }
        }

        private void CheckJumpInput()
        {
            if (_pressedButtonTime + JumpInputStartTime <= Time.time)
            {
                JumpInput = false;
            }
        }
    }
}
