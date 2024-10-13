using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class HateSpell:Spell
    {
        [SerializeField] private Vector2Int _attackValueEnemy;
        [SerializeField] private Vector2Int _attackValuePlayer;
        public override void DoSpell()
        { 
            _enemy.TakeDamage(Random.Range( _attackValueEnemy.x, _attackValueEnemy.y), new Vector2Int((int)typeOne, (int)typeTwo));
            _player.HealthController.TakeDamage(Random.Range(_attackValuePlayer.x, _attackValuePlayer.y));

        }
    }
}
