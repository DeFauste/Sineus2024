using Assets.Scripts.Spell.SpellTurn;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class HealingSpell: Spell
    {
        [SerializeField] private int _healthValue = 2;
        [SerializeField] private int _turnHealing = 1;
        public override void DoSpell()
        {
           _player.HealthController.AddHealth(_healthValue);
            var gObject = GameObject.FindGameObjectWithTag("Player");
            ITurnSpell turn = gObject.GetComponent<HealingSpellTurn>();
            turn.SetTurn(_turnHealing);           
        }
    }
}
