using NowakArtur97.LoopedDungeon.Input;
using NowakArtur97.LoopedDungeon.Rewind;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class InputRecorder : CoreComponent
    {
        private D_Rewind _rewindData;
        private Input _characterInput;
        private PlayerCoreContainer _playerCoreContainer;
        private bool _isRecording;
        private float _recordingStartTime;

        public List<PlayerInputFrame> InputsFrames { get; private set; }
        public Action OnRecorded;

        protected override void Awake()
        {
            base.Awake();

            InputsFrames = new List<PlayerInputFrame>();
            _isRecording = true;

            if (CoreContainer is PlayerCoreContainer)
            {
                _playerCoreContainer = (PlayerCoreContainer)CoreContainer;
            }
        }

        private void Start() => _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                Record();

                if (Time.time > _rewindData.rewindTime + _recordingStartTime)
                {
                    _isRecording = false;
                    _characterInput.IsRecording = false;
                    // TODO: InputReplayer: REMOVE
                    _characterInput.StoppedRewinding = true;
                    OnRecorded?.Invoke();
                }
            }
        }

        public void StartRecording()
        {
            _recordingStartTime = Time.time;
            _characterInput = _playerCoreContainer.Input;
            _characterInput.IsRecording = true;
            // TODO: InputReplayer: REMOVE
            _characterInput.StoppedRewinding = false;
            _isRecording = true;
        }

        private void Record() => InputsFrames.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
         _characterInput.JumpInputStartTime, _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
    }
}
