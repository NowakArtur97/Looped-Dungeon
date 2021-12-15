using NowakArtur97.LoopedDungeon.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputPlayer : MonoBehaviour
    {
        [SerializeField] private D_Rewind _rewindData;

        private CharacterSpawner _characterSpawner;
        private InputRecored _inputRecored;
        private int _frameIndex;
        private Dictionary<Core.Input, List<PlayerInputFrame>> _characterInputs;
        private bool _isReplaying;
        private float _replayingStartTime;
        public Action OnReplayedEvent;

        private void Awake()
        {
            _characterSpawner = FindObjectOfType<CharacterSpawner>();
            _characterSpawner.OnSpawnCharacterEvent += StartReplaying;

            _inputRecored = FindObjectOfType<InputRecored>();
        }

        private void OnDestroy() => _characterSpawner.OnSpawnCharacterEvent -= StartReplaying;

        private void FixedUpdate()
        {
            if (_isReplaying)
            {
                foreach (var characterInput in _characterInputs)
                {
                    Replay(characterInput.Key);
                }
                _frameIndex++;
            }

            if (Time.time > _rewindData.rewindTime + _replayingStartTime)
            {
                _isReplaying = false;
                OnReplayedEvent?.Invoke();
            }
        }

        private void StartReplaying(GameObject character)
        {
            _frameIndex = 0;
            _characterInputs = _inputRecored.CharacterInputs;
            _replayingStartTime = Time.time;
            _isReplaying = true;
        }

        private void Replay(Core.Input characterInput)
        {
            if (_frameIndex < _characterInputs[characterInput].Count)
            {
                PlayerInputFrame inputFrame = _characterInputs[characterInput][_frameIndex];
                characterInput.SetMovement(inputFrame, _replayingStartTime);
            }
        }
    }
}
