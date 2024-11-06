using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class RainWallSpell : Spell
    {

        [SerializeField] private Vector2Int _attackValue;
        [SerializeField] private int _turnBlinding = 1;
        [SerializeField] private int _percentBlinding = 50;

        public override void DoSpell()
        {
            _enemy.TakeDamage(Random.Range(_attackValue.x, _attackValue.y), new Vector2Int((int)typeOne, (int)typeTwo));
            var gObject = GameObject.FindGameObjectWithTag("Enemy");
            ITurnSpell turn = gObject.GetComponent<BlindingTurn>();
            turn.SetTurn(_turnBlinding);
       
        }
    }
}
