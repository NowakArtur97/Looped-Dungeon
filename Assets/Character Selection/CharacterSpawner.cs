using NowakArtur97.LoopedDungeon.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;

        private List<CharacterSelectionButton> _characterSelectionButtons;
        private List<GameObject> _spawnedCharacters;
        private int _spawnIndex;
        public Action<GameObject> OnSpawnCharacterEvent;

        private void Awake()
        {
            _characterSelectionButtons = new List<CharacterSelectionButton>(FindObjectsOfType<CharacterSelectionButton>());
            _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent += SpawnCharacters);

            _spawnedCharacters = new List<GameObject>();
        }

        private void OnDestroy() => _characterSelectionButtons.ForEach(selectionButton => selectionButton.OnSelectCharacterEvent -= SpawnCharacters);

        private void SpawnCharacters(GameObject spawnedCharacter)
        {
            _spawnIndex = 0;
            _spawnedCharacters.Add(spawnedCharacter);
            _spawnedCharacters.ForEach(character =>
            {
                character.SetActive(true);
                character.transform.position = _spawnPositions[_spawnIndex++].position;
            });
            OnSpawnCharacterEvent?.Invoke(spawnedCharacter);
        }
    }
}
