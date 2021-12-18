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
        private InputReplayer _inputReplayer;
        private PlayerCoreContainer _playerCoreContainer;

        public bool IsRecording;
        public List<PlayerInputFrame> InputsFrames { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            InputsFrames = new List<PlayerInputFrame>();
            IsRecording = true;

            if (CoreContainer is PlayerCoreContainer)
            {
                _playerCoreContainer = (PlayerCoreContainer)CoreContainer;
            }
        }

        private void Start()
        {
            _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;
            _characterInput = _playerCoreContainer.Input;
            _inputReplayer = _playerCoreContainer.InputReplayer;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (IsRecording)
            {
                Record();

                if (Time.time > _rewindData.rewindTime)
                {
                    IsRecording = false;
                    _characterInput.IsRecording = false;
                    _inputReplayer.IsReplaying = true;
                    _inputReplayer.ReplayingStartTime = Time.time;
                }
            }
        }

        private void Record() => InputsFrames.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
         _characterInput.JumpInputStartTime, _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
    }
}
