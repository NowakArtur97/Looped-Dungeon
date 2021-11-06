using System;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionButton : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private GameObject _characterSelectionUI;

        public Action<GameObject> OnSelectCharacterEvent;

        public void OnSelectCharacter()
        {
            OnSelectCharacterEvent.Invoke(_character);
            _characterSelectionUI.gameObject.SetActive(false);
        }
    }
}
