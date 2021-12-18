using NowakArtur97.LoopedDungeon.Core;
using NowakArtur97.LoopedDungeon.Rewind;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// TODO: InputPlayer: REMOVE
namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputPlayer : MonoBehaviour
    {
        private D_Rewind _rewindData;

        private CharacterSpawner _characterSpawner;
        private InputRecored _inputRecored;
        private int _frameIndex;
        private Dictionary<Core.Input, List<PlayerInputFrame>> _characterInputs;
        private bool _isReplaying;
        private bool _isRewinding;
        private bool _isFinished;
        private float _replayingStartTime;
        public Action OnRewindedEvent;

        private void Awake()
        {
            _characterSpawner = FindObjectOfType<CharacterSpawner>();
            _characterSpawner.OnSpawnCharacterEvent += StartReplaying;

            _inputRecored = FindObjectOfType<InputRecored>();
        }

        private void Start() => _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;

        private void OnDestroy()
        {
            _characterSpawner.OnSpawnCharacterEvent -= StartReplaying;
        }

        private void FixedUpdate()
        {
            if (_isReplaying)
            {
                foreach (var characterInput in _characterInputs)
                {
                    Replay(characterInput.Key);
                }
                _frameIndex++;

                if (Time.time > _rewindData.rewindTime + _replayingStartTime)
                {
                    _isReplaying = false;
                    _isRewinding = true;
                    _replayingStartTime = Time.time;
                }
            }

            if (_isRewinding)
            {
                _frameIndex--;
                foreach (var characterInput in _characterInputs)
                {
                    Rewind(characterInput.Key);
                }

                if (Time.time > _rewindData.rewindTime + _replayingStartTime)
                {
                    _characterInputs.Keys.ToList().ForEach(input => input.StoppedRewinding = true);
                    _isRewinding = false;
                    _isFinished = true;
                }
            }
            if (_isFinished)
            {
                OnRewindedEvent?.Invoke();
            }
        }

        private void StartReplaying(GameObject character)
        {
            _frameIndex = 0;
            _isFinished = false;
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

        private void Rewind(Core.Input characterInput)
        {
            if (_frameIndex >= 0)
            {
                PlayerInputFrame inputFrame = _characterInputs[characterInput][_frameIndex];
                PlayerInputFrame rewindInputFrame = inputFrame.Clone();
                rewindInputFrame.MovementInput.x = -inputFrame.MovementInput.x;
                characterInput.SetMovement(rewindInputFrame, _replayingStartTime);
            }
        }
    }
}
