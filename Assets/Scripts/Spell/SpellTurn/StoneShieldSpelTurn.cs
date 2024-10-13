using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Spell.SpellTurn
{
    internal class StoneShieldSpelTurn : BaseSpellTurn
    {
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                if(turnCount == 2) _entity._stateController.Shield = 100;
                if(turnCount == 1) _entity._stateController.Shield = 60;
                turnCount--;
            }
            if (turnCount <= 0)
            {
                ClearTurn();
            }
        }
    }
}
