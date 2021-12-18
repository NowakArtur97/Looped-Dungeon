using NowakArtur97.LoopedDungeon.Core;
using System;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.UI
{
    public class CharacterSelectionButton : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        public Action<GameObject> OnSelectCharacterEvent;

        public void OnSelectCharacter() => OnSelectCharacterEvent?.Invoke(_character);
    }
}
