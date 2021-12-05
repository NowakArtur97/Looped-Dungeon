using NowakArtur97.LoopedDungeon.Util;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class EnemySenses : CoreComponent
    {
        [SerializeField] private Transform _playerCheck;
        [SerializeField] private LayerMask _whatIsPlayer;
        [SerializeField] private float _enemyCheckDistance = 15f;

        public Transform PlayerCheck
        {
            get => GenericUtil<Transform>.GetOrDefault(_playerCheck, CoreContainer.transform.name);
            private set => _playerCheck = value;
        }

        public bool IsPlayerInAgroRange(float range) => Physics2D.Raycast(_playerCheck.position, transform.right, range, _whatIsPlayer)
            .transform?.gameObject.tag == "Player";
        public bool IsPlayerUnder => Physics2D.Raycast(_playerCheck.position, Vector2.down, _enemyCheckDistance, _whatIsPlayer)
            .transform?.gameObject.tag == "Player";
    }
}
