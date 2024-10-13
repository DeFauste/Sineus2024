namespace Assets.Scripts.Spell.SpellTurn
{
    public class FreezeTurn :BaseSpellTurn
    {
        public int PercentFreeze = 40;
        public override void DoTick()
        {
            if (turnCount > 0)
            {
                _entity._stateController.IsFreezing = PercentFreeze;
                turnCount--;
            }
            if (turnCount <= 0)
            {
                _entity._stateController.IsFreezing = 0;
                ClearTurn();
            }
        }
    }
}
