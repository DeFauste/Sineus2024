using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class StoneShieldSpell : Spell
    {
        [SerializeField] private int _turn = 2;
        public override void DoSpell()
        {
            var gObject = GameObject.FindGameObjectWithTag("Player");
            ITurnSpell turn = gObject.GetComponent<StoneShieldSpelTurn>();
            turn.SetTurn(_turn);
        }
    }
}
