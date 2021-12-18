using NowakArtur97.LoopedDungeon.Input;
using NowakArtur97.LoopedDungeon.Rewind;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class InputReplayer : CoreComponent
    {
        private PlayerCoreContainer _playerCoreContainer;
        private D_Rewind _rewindData;
        private Input _characterInput;
        private int _frameIndex;
        private List<PlayerInputFrame> _inputsFrames;
        private float _replayingStartTime;

        public bool IsReplaying { get; private set; }
        public Action OnReplayed;

        protected override void Awake()
        {
            base.Awake();

            if (CoreContainer is PlayerCoreContainer)
            {
                _playerCoreContainer = (PlayerCoreContainer)CoreContainer;
            }
        }

        private void Start()
        {
            _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;
            _inputsFrames = _playerCoreContainer.InputRecored.InputsFrames;
        }

        private void FixedUpdate()
        {
            if (IsReplaying)
            {
                Replay();

                if (Time.time > _rewindData.rewindTime + _replayingStartTime)
                {
                    IsReplaying = false;
                    // TODO: InputReplayer: REMOVE
                    _characterInput.StoppedRewinding = true;
                    OnReplayed?.Invoke();
                }
            }
        }

        public void StartReplaying()
        {
            _replayingStartTime = Time.time;
            IsReplaying = true;
            _characterInput = _playerCoreContainer.Input;
            // TODO: InputReplayer: REMOVE
            _characterInput.StoppedRewinding = false;
            _frameIndex = 0;
        }

        private void Replay()
        {
            if (_frameIndex < _inputsFrames.Count)
            {
                PlayerInputFrame inputFrame = _inputsFrames[_frameIndex];
                _characterInput.SetMovement(inputFrame, _replayingStartTime);
                _frameIndex++;
            }
        }
    }
}
