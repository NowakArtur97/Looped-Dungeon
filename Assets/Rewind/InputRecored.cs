using NowakArtur97.LoopedDungeon.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Input
{
    public class InputRecored : MonoBehaviour
    {
        [SerializeField] private float _recordingTime = 10f;

        private CharacterSpawner _characterSpawner;
        private Core.Input _characterInput;
        private Coroutine _recordCoroutine;
        private Coroutine _replayCoroutine;
        private List<PlayerInputFrame> _inputs = new List<PlayerInputFrame>();
        private int replayIndex;
        private bool _isReplaying;
        private float _startTime;

        private void Awake()
        {
            _characterSpawner = FindObjectsOfType<CharacterSpawner>()[0];
            _characterSpawner.SpawnCharacterEvent += StartRecording;
        }

        // TODO: REFACTOR
        private void Update()
        {
            if (Time.time > _recordingTime + _startTime)
            {
                _isReplaying = true;
                StopCoroutine(_recordCoroutine);
                _characterInput.IsRecording = false;
                _replayCoroutine = StartCoroutine(Replay());
            }
        }

        private void StartRecording(GameObject character)
        {
            _startTime = Time.time;
            _characterInput = character.GetComponentInChildren<Core.Input>();
            _recordCoroutine = StartCoroutine(Record());
        }

        private IEnumerator Record()
        {
            while (true)
            {
                _inputs.Add(new PlayerInputFrame(_characterInput.MovementInput, _characterInput.JumpInput,
                    _characterInput.MainAbilityInput, _characterInput.SecondaryAbilityInput));
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator Replay()
        {
            while (true && replayIndex < _inputs.Count)
            {
                _characterInput.SetMovement(_inputs[replayIndex++]);
                yield return new WaitForEndOfFrame();
            }
        }

        private void OnDestroy() => _characterSpawner.SpawnCharacterEvent -= StartRecording;
    }
}
