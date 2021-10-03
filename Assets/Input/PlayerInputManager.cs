using UnityEngine;
using UnityEngine.InputSystem;

namespace NowakArtur97.LoopedDungeon.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private Vector2 _workspace;

        public Vector2 MovementInput { get; private set; }

        private void Awake() => _playerInput = GetComponent<PlayerInput>();

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            _workspace = context.ReadValue<Vector2>();
            _workspace.Set(Mathf.RoundToInt(_workspace.x), Mathf.RoundToInt(_workspace.y));
            MovementInput = _workspace;
        }
    }
}
