using UnityEngine;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class HealingSpellTurn : BaseSpellTurn
    {
        [SerializeField] private int _healingValue;
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity.HealthController.AddHealth(_healingValue);
                turnCount--;
            }
            if (turnCount <= 0)
            {
                ClearTurn();
            }
        }
    }
}
