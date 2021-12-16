using NowakArtur97.LoopedDungeon.Input;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionCanvas : MonoBehaviour
    {
        private InputPlayer _inputPlayer;
        private List<CharacterSelectionButton> _characterSelectionButtons;

        private void Awake()
        {
            _inputPlayer = FindObjectOfType<InputPlayer>();
            _inputPlayer.OnRewindedEvent += EnableUI;

            _characterSelectionButtons = new List<CharacterSelectionButton>(FindObjectsOfType<CharacterSelectionButton>());
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent += DisableUI);
        }

        private void OnDestroy()
        {
            _inputPlayer.OnRewindedEvent -= EnableUI;
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent -= DisableUI);
        }

        private void EnableUI() => gameObject.SetActive(true);

        private void DisableUI(GameObject character) => gameObject.SetActive(false);
    }
}
