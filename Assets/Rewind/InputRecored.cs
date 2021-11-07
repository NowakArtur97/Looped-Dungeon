using NowakArtur97.LoopedDungeon.Core;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputRecored : MonoBehaviour
    {
        [SerializeField] private float _recordingTime = 10f;

        private CharacterSpawner _characterSpawner;
        private Core.Input _characterInput;
        private List<PlayerInputFrame> _inputs = new List<PlayerInputFrame>();
        private int _replayIndex;
        private bool _isRecording;
        private float _startTime;

        private void Awake()
        {
            _characterSpawner = FindObjectsOfType<CharacterSpawner>()[0];
            _characterSpawner.SpawnCharacterEvent += StartRecording;
        }

        // TODO: REFACTOR
        private void FixedUpdate()
        {
            if (_isRecording)
            {
                Record();
            }
            else if (_inputs.Count > 0)
            {
                _characterInput.IsRecording = false;
                Replay();
            }

            if (Time.time > _recordingTime + _startTime)
            {
                _isRecording = false;
            }
        }

        private void StartRecording(GameObject character)
        {
            _startTime = Time.time;
            _replayIndex = 0;
            _characterInput = character.GetComponentInChildren<Core.Input>();
            _isRecording = true;
        }

        private void Record() => _inputs.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
                _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));

        private void Replay()
        {
            if (_replayIndex < _inputs.Count)
            {
                PlayerInputFrame frame = _inputs[_replayIndex];
                _characterInput.SetMovement(frame);
                _replayIndex++;
            }
        }

        private void OnDestroy() => _characterSpawner.SpawnCharacterEvent -= StartRecording;
    }
}
