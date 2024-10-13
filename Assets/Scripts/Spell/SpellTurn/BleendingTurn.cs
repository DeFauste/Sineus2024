using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Spell.SpellTurn
{
    //Кровотечение
    public class BleendingTurn: BaseSpellTurn
    {
        [SerializeField] private int _attackValue;
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity.HealthController.TakeDamage(_attackValue);
                turnCount--;
            }
            if (turnCount <= 0)
            {
                ClearTurn();
            }
        }
    }
}
