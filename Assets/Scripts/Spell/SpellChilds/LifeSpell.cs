using Assets.Scripts.Spell.SpellTurn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellChilds
{
    public class LifeSpell : Spell
    {
        [SerializeField] private int _healthValue = 15;
        [SerializeField] private int _turnHealing = 2;
        [SerializeField] private int _turnBash = 1;
        public override void DoSpell()
        {
            _player.HealthController.AddHealth(_healthValue);
            var gObject = GameObject.FindGameObjectWithTag("Player");
            ITurnSpell turn = gObject.GetComponent<HealingSpellTurn>();
            turn.SetTurn(_turnHealing);
            gObject = GameObject.FindGameObjectWithTag("Enemy");
            turn = gObject.GetComponent<BashSpellTurn>();
            turn.SetTurn(_turnHealing);
        }
    }
}
