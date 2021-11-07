using NowakArtur97.LoopedDungeon.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputRecored : MonoBehaviour
    {
        // TODO: REFACTOR
        [SerializeField] private float _recordingTime = 10f;

        private CharacterSpawner _characterSpawner;
        private Core.Input _characterInput;
        private List<PlayerInputFrame> _inputs;
        private bool _isRecording;
        private float _startTime;

        public Dictionary<Core.Input, List<PlayerInputFrame>> CharacterInputs { get; private set; }
        public Action OnRecordedEvent;

        private void Awake()
        {
            _characterSpawner = FindObjectOfType<CharacterSpawner>();
            _characterSpawner.OnSpawnCharacterEvent += StartRecording;

            CharacterInputs = new Dictionary<Core.Input, List<PlayerInputFrame>>();
        }

        private void OnDestroy() => _characterSpawner.OnSpawnCharacterEvent -= StartRecording;

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                Record();
            }

            if (_isRecording && Time.time > _recordingTime + _startTime)
            {
                _isRecording = false;
                _characterInput.IsRecording = false;
                CharacterInputs.Add(_characterInput, _inputs);
                OnRecordedEvent?.Invoke();
            }
        }

        private void StartRecording(GameObject spawnedCharacter)
        {
            _inputs = new List<PlayerInputFrame>();
            _characterInput = spawnedCharacter.GetComponentInChildren<Core.Input>();
            _startTime = Time.time;
            _isRecording = true;
        }

        private void Record() => _inputs.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
                _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
    }
}
