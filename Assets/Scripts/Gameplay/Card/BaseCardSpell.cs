using Assets.Scripts.Gameplay.Characters;
using Assets.Scripts.Gameplay.Spell;
using System.Collections.Generic;

namespace Assets.Scripts.Gameplay.Card
{
    public class BaseCardSpell
    {
        protected BaseCharacter _player, _enemy;
        protected List<BaseSpell> _spellsList = new();
        protected List<Elements> _elementList = new List<Elements>();

        public BaseCardSpell(BaseCharacter player, BaseCharacter enemy) 
        {
            _player = player;
            _enemy = enemy;
            AddSpell();
        }

        public List<BaseSpell> GetSpells() => _spellsList;
        public List<Elements> GetElementList() => _elementList;
        protected virtual void AddSpell()
        {

        }
    }
}
