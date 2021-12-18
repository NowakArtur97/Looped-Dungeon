using NowakArtur97.LoopedDungeon.Input;
using System;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionButton : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        private bool _wasSelected;
        private InputPlayer _inputPlayer;

        public Action<GameObject> OnSelectCharacterEvent;

        private void Awake()
        {
            _inputPlayer = FindObjectOfType<InputPlayer>();
            //_inputPlayer.OnRewindedEvent += EnableButton;
        }

        private void OnDestroy() => _inputPlayer.OnRewindedEvent -= EnableButton;

        public void OnSelectCharacter()
        {
            _wasSelected = true;
            OnSelectCharacterEvent?.Invoke(_character);
        }

        private void EnableButton() => gameObject.SetActive(!_wasSelected);
    }
}
