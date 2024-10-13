using UnityEngine;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class DistractionTurn: BaseSpellTurn
    {
        [SerializeField] private int _percentDistraction = 50;
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity._stateController.Distraction = _percentDistraction;
                turnCount--;
            }
            if (turnCount <= 0)
            {
                _entity._stateController.Distraction = 0;
                ClearTurn();
            }
        }
    }
}
