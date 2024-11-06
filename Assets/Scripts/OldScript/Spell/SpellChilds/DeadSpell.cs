using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class DeadSpell : Spell
    {
        [SerializeField] private int _percentAttackValueEnemy;
        [SerializeField] private int _percentAttackValuePlayer;
        public override void DoSpell()
        {
            float enemyHealth = _enemy.HealthController.Health;
            _enemy.TakeDamage((int)enemyHealth*(_percentAttackValueEnemy/100), new Vector2Int((int)typeOne, (int)typeTwo));
            float _playerHealth = _player.HealthController.Health;
            _player.HealthController.TakeDamage(_percentAttackValuePlayer);

        }
    }
}
