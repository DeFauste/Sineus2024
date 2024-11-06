using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class FireSpell: Spell
    {
        [SerializeField] private int _attackValue = 2;
        [SerializeField] private int _turnAttack = 1;
        public override void DoSpell()
        {
            _enemy.TakeDamage(_attackValue, new Vector2Int((int)typeOne, (int)typeTwo));
            var gObject = GameObject.FindGameObjectWithTag("Enemy");
            ITurnSpell turn = gObject.GetComponent<FireSpellTurn>();
            turn.SetTurn(_turnAttack);
        }
    }
}
