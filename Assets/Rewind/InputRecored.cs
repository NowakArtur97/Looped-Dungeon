using NowakArtur97.LoopedDungeon.Core;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NowakArtur97.LoopedDungeon.Rewind;

// TODO: InputRecored : REMOVE
namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputRecored : MonoBehaviour
    {
        private D_Rewind _rewindData;

        private CharacterSpawner _characterSpawner;
        private Core.Input _characterInput;
        private List<PlayerInputFrame> _inputsFrames;
        private bool _isRecording;
        private float _recordingStartTime;

        public Dictionary<Core.Input, List<PlayerInputFrame>> CharacterInputs { get; private set; }

        private void Awake()
        {
            _characterSpawner = FindObjectOfType<CharacterSpawner>();
            _characterSpawner.OnSpawnCharacterEvent += StartRecording;

            CharacterInputs = new Dictionary<Core.Input, List<PlayerInputFrame>>();
        }

        private void Start() => _rewindData = FindObjectOfType<RewindDataHolder>().RewindData;

        private void OnDestroy() => _characterSpawner.OnSpawnCharacterEvent -= StartRecording;

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                Record();

                if (Time.time > _rewindData.rewindTime + _recordingStartTime)
                {
                    _isRecording = false;
                    _characterInput.IsRecording = false;
                    CharacterInputs.Add(_characterInput, _inputsFrames);
                }
            }
        }

        private void StartRecording(GameObject spawnedCharacter)
        {
            CharacterInputs.Keys.ToList().ForEach(input => input.StoppedRewinding = false);
            _inputsFrames = new List<PlayerInputFrame>();
            _characterInput = spawnedCharacter.GetComponentInChildren<Core.Input>();
            _characterInput.IsRecording = true;
            _recordingStartTime = Time.time;
            _isRecording = true;
        }

        private void Record() => _inputsFrames.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
         _characterInput.JumpInputStartTime, _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
    }
}
