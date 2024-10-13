using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class VolcanoSpell :Spell
    {
        [SerializeField] private Vector2Int _attackValue;
        [SerializeField] private int _turnBash = 1;
        [SerializeField] private int _percentBash = 50;

        public override void DoSpell()
        {
            _enemy.TakeDamage(Random.Range(_attackValue.x, _attackValue.y), new Vector2Int((int)typeOne, (int)typeTwo));
            if(Random.Range(0,100) < _percentBash)
            {
                var gObject = GameObject.FindGameObjectWithTag("Enemy");
                ITurnSpell turn = gObject.GetComponent<BashSpellTurn>();
                turn.SetTurn(_turnBash);
            }
        }
    }
}
