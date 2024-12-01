using Assets.Scripts.Gameplay.Characters;
using System.Collections.Generic;

namespace Assets.Scripts.Gameplay.Spell
{
    public class BaseSpell
    {
        protected AttackData _attackData;
        protected List<Elements> _elementsPhy = new List<Elements>() { Elements.None };
        protected List<Elements> _elementsMag = new List<Elements>() { Elements.None };
        protected BaseCharacter _player;
        protected BaseCharacter _enemy;
        public int ValuePhyAttack { get; set; } = 0;
        public int ValueMagAttack { get; set; } = 0;
        public int StepAttack { get; set; } = 0;
        public BaseSpell(BaseCharacter player, BaseCharacter enemy, List<Elements> elementsPhy = null, List<Elements> elementsMag = null)
        {
            _player = player;
            _enemy = enemy;
            if (elementsPhy != null) _elementsPhy = elementsPhy;
            if (elementsMag != null) _elementsMag = elementsMag;
        }
        public virtual void Interact()
        {

        }
    }
}