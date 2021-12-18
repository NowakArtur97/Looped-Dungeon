using NowakArtur97.LoopedDungeon.Input;
using NowakArtur97.LoopedDungeon.Rewind;
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

        public bool IsReplaying;
        public float ReplayingStartTime;

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
            _characterInput = _playerCoreContainer.Input;
            _characterInput.IsRecording = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (IsReplaying)
            {
                Replay();

                if (Time.time > _rewindData.rewindTime + ReplayingStartTime)
                {
                    IsReplaying = false;
                }
            }
        }

        private void Replay()
        {
            if (_frameIndex < _inputsFrames.Count)
            {
                PlayerInputFrame inputFrame = _inputsFrames[_frameIndex];
                _characterInput.SetMovement(inputFrame, ReplayingStartTime);
                _frameIndex++;
            }
        }
    }
}
