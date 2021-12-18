using NowakArtur97.LoopedDungeon.Input;
using NowakArtur97.LoopedDungeon.Rewind;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionCanvas : MonoBehaviour
    {
        private D_Rewind _rewindData;
        private float _startTime;
        private List<CharacterSelectionButton> _characterSelectionButtons;

        private void Awake()
        {
            _characterSelectionButtons = new List<CharacterSelectionButton>(FindObjectsOfType<CharacterSelectionButton>());
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent += DisableUI);
        }

        private void Start() => _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;

        private void Update()
        {
            if (Time.time > _rewindData.rewindTime + _startTime)
            {
                EnableUI();
            }
        }

        private void OnDestroy() => _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent -= DisableUI);

        private void EnableUI() => gameObject.SetActive(true);

        private void DisableUI(GameObject character)
        {
            gameObject.SetActive(false);
            _startTime = Time.time;
        }
    }
}
