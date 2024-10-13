using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class FireBallSpell: Spell
    {
        [SerializeField] private int _attackValueMin = 20;
        [SerializeField] private int _attackValueMax = 24;
        public override void DoSpell()
        { 
            _enemy.TakeDamage(Random.Range(_attackValueMax, _attackValueMax), new Vector2Int((int)typeOne, (int)typeTwo));
        }
    }
}
