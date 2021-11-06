using NowakArtur97.LoopedDungeon.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        private List<CharacterSelectionButton> _characterSelectionButtons;
        private int characterIndex;
        public Action<GameObject> SpawnCharacterEvent;

        private void Awake()
        {
            _characterSelectionButtons = new List<CharacterSelectionButton>(FindObjectsOfType<CharacterSelectionButton>());
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent += SpawnCharacter);
        }

        private void OnDestroy() => _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent -= SpawnCharacter);

        private void SpawnCharacter(GameObject character)
        {
            character.SetActive(true);
            character.transform.position = _spawnPositions[characterIndex++].position;
            SpawnCharacterEvent?.Invoke(character);
        }
    }
}
