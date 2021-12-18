using NowakArtur97.LoopedDungeon.Input;
using NowakArtur97.LoopedDungeon.Rewind;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class InputRecored : CoreComponent
    {
        private D_Rewind _rewindData;
        private Input _characterInput;
        private List<PlayerInputFrame> _inputsFrames;
        private bool _isRecording;
        private PlayerCoreContainer _playerCoreContainer;

        protected override void Awake()
        {
            base.Awake();

            _inputsFrames = new List<PlayerInputFrame>();
            _isRecording = true;

            if (CoreContainer is PlayerCoreContainer)
            {
                _playerCoreContainer = (PlayerCoreContainer)CoreContainer;
            }
        }

        private void Start()
        {
            _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;
            _characterInput = _playerCoreContainer.Input;
            _characterInput.IsRecording = _isRecording;
        }

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                Record();

                if (Time.time > _rewindData.rewindTime)
                {
                    _isRecording = false;
                    _playerCoreContainer.Input.IsRecording = _isRecording;
                }
            }
        }

        private void Record() => _inputsFrames.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
         _characterInput.JumpInputStartTime, _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
    }
}
