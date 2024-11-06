using UnityEngine;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class PoisonTurn: BaseSpellTurn
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
