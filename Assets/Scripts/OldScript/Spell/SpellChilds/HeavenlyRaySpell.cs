using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class HeavenlyRaySpell : Spell
    {
        [SerializeField] private Vector2Int _attackValue;
        [SerializeField] private int _turn = 2;
        public override void DoSpell()
        {
            _enemy.TakeDamage(Random.Range(_attackValue.x, _attackValue.y), new Vector2Int((int)typeOne, (int)typeTwo));
            var gObject = GameObject.FindGameObjectWithTag("Enemy");
            ITurnSpell turn = gObject.GetComponent<BlindingTurn>();
            turn.SetTurn(_turn);
            turn = gObject.GetComponent<DistractionTurn>();
            turn.SetTurn(_turn);
        }
    }
}
