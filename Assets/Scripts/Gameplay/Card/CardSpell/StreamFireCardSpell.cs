using Assets.Scripts.Gameplay.Characters;
using Assets.Scripts.Gameplay.Spell;
using System.Collections.Generic;

namespace Assets.Scripts.Gameplay.Card.CardSpell
{
    public class StreamFireCardSpell : BaseCardSpell
    {
        public StreamFireCardSpell(BaseCharacter player, BaseCharacter enemy) : base(player, enemy)
        {
        }

        protected override void AddSpell()
        {
            _elementList.Add(Elements.Fire);
            _elementList.Add(Elements.Fire);
            BaseSpell oneShot = new SingleAttack(_player, _enemy, _elementList, _elementList);//одиночная атака
            oneShot.ValuePhyAttack = 5;
            _spellsList.Add(oneShot);

            BaseSpell burning = new SingleAttack(_player, _enemy, _elementList, _elementList);//горение
            burning.ValueMagAttack = 5;
            burning.StepAttack = 3;
            _spellsList.Add(burning);
        }
    }
}
