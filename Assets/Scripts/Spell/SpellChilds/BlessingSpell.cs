using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class BlessingSpell : Spell
    {
        [SerializeField] private Vector2Int _attack;
        public override void DoSpell()
        {
            _enemy.TakeDamage(Random.Range(_attack.x, _attack.y), new Vector2Int((int)typeOne, (int)typeTwo));
            _player._stateController.ClearNegativeState();
        }
    }
}
