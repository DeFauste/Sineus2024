using Assets.Scripts.Gameplay.Characters;
using System.Collections.Generic;

namespace Assets.Scripts.Gameplay.Spell
{
    public class SingleAttack:BaseSpell
    {
        public SingleAttack(BaseCharacter player, BaseCharacter enemy, List<Elements> elementsPhy = null, List<Elements> elementsMag = null) : base(player, enemy, elementsPhy, elementsMag)
        {
        }

        private void Init()
        {
            _attackData = new AttackData(ValueMagAttack, ValuePhyAttack, _elementsMag, _elementsPhy);
        }

        public override void Interact()
        {
            if(_attackData == null) Init();
            _enemy.Attack(_attackData);
        }
    }
}
