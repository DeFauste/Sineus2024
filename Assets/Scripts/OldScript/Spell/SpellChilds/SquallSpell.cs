using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class SquallSpell : Spell
    {
        [SerializeField] private int _percentBlinding = 50;
        [SerializeField] private int _percentDistraction = 50;
        [SerializeField] private int _turnBash = 2;

        public override void DoSpell()
        {
            var gObject = GameObject.FindGameObjectWithTag("Enemy");
            ITurnSpell turn = gObject.GetComponent<BlindingTurn>();
            turn.SetTurn(_turnBash);
            turn = gObject.GetComponent<DistractionTurn>();
            turn.SetTurn(_turnBash);

        }
    }
}
