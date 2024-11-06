using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class BashSpellTurn: BaseSpellTurn
    {
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity._stateController.IsBash = true;
                turnCount--;
            }
            if (turnCount <= 0)
            {
                _entity._stateController.IsBash = false;
                ClearTurn();
            }
        }
    }
}
