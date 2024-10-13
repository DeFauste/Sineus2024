using UnityEngine;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class BlindingTurn : BaseSpellTurn
    {
        [SerializeField] private int _percentBlinding = 50;
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity._stateController.Blinding = _percentBlinding;
                turnCount--;
            }
            if (turnCount <= 0)
            {
                _entity._stateController.Blinding = 0;
                ClearTurn();
            }
        }
    }
}
