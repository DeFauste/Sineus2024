using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Characters
{
    public class BaseCharacter: MonoBehaviour
    {
        private CharacterData _characterData;
        private BaseCharacter(CharacterData characterData)
        {
            _characterData = characterData;
        }
        
        public void Attack(AttackData attack)
        {
           int physical = BoostAttack(attack.PhysicalValue, attack.PhysicalElements);
           int magic = BoostAttack(attack.MagicValue, attack.MagicElements);
        }

        private int BoostAttack(int value, List<Elements> elements)
        {
            if(value <= 0) return 0;
            foreach(Elements element in elements)
            {
               value = BoostAttackValue(value, element);
            }

            return value;
        }

        private int BoostAttackValue(int value, Elements element)
        {
            switch(element)
            {
                case Elements.Air:
                    value = value * (1 - _characterData.StabilityAir);
                    break;
                case Elements.Fire:
                    value = value * (1 - _characterData.StabilityFire);
                    break;
                case Elements.Earth:
                    value = value * (1 - _characterData.StabilityEarth);
                    break;
                case Elements.Grief:
                    value = value * (1 - _characterData.StabilityGrief);
                    break;
                case Elements.Sun:
                    value = value * (1 - _characterData.StabilitySun);
                    break;
                case Elements.Water:
                    value = value * (1 - _characterData.StabilityWater);
                    break;
            }
            return value;
        }
    }
}
