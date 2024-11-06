using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class ApathySpell: Spell
    {
        [SerializeField] private int _attackhValue = 2;
        [SerializeField] private int _turnBash = 2;
        public override void DoSpell()
        {
            _player.HealthController.TakeDamage(_attackhValue);
            var gObject = GameObject.FindGameObjectWithTag("Enemy");
            ITurnSpell turn = gObject.GetComponent<BashSpellTurn>();
            turn.SetTurn(_turnBash);
        }
    }
}
