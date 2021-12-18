using NowakArtur97.LoopedDungeon.Core;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionCanvas : MonoBehaviour
    {
        private List<InputRecorder> _inputRecorders;
        private List<InputReplayer> _inputReplayers;
        private List<CharacterSelectionButton> _characterSelectionButtons;

        private void Awake()
        {
            _characterSelectionButtons = new List<CharacterSelectionButton>(FindObjectsOfType<CharacterSelectionButton>());
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent += DisableUI);

            _inputRecorders = new List<InputRecorder>();
            _inputReplayers = new List<InputReplayer>();
        }

        private void OnDestroy()
        {
            _inputRecorders.ForEach(inputRecorder => inputRecorder.OnRecorded -= EnableUI);
            _inputReplayers.ForEach(inputReplayer => inputReplayer.OnReplayed -= EnableUI);
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent -= DisableUI);
        }

        private void EnableUI() => gameObject.SetActive(true);

        private void DisableUI(GameObject character)
        {
            InputRecorder _inputRecorder = character.GetComponentInChildren<InputRecorder>();
            _inputRecorder.OnRecorded += EnableUI;
            _inputRecorders.Add(_inputRecorder);
            InputReplayer inputReplayer = character.GetComponentInChildren<InputReplayer>();
            inputReplayer.OnReplayed += EnableUI;
            _inputReplayers.Add(inputReplayer);

            gameObject.SetActive(false);
        }
    }
}
