using Assets.Scripts.Core.Services.Popup;
using Assets.Scripts.Gameplay.Popup;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Characters
{
    public class BaseCharacter: MonoBehaviour
    {
        [SerializeField] private PopupService _popupManager;
        [SerializeField] private CharacterData characterData;
        [SerializeField] private Transform positionPopup;
        private CharacterData _characterData;

        private void Start()
        {
            Init();
        }

        public void Init() 
        {
            _characterData = Instantiate(characterData);
        }
        public void Attack(AttackData attack)
        {
            float physical = BoostAttack(attack.PhysicalValue, attack.PhysicalElements);
            float magic = BoostAttack(attack.MagicValue, attack.MagicElements);
            float health = _characterData.Health;
            health = health - physical;
            health = health - magic;
            if (health <= 0)
            {
                Debug.Log("Герой умер");
            }
            else
            {
                Debug.Log($"Жизни {health} Урон Ф {physical} Урон М {magic}");
            }
            _characterData.Health = (int)health;
            _popupManager.Intarcat().CreatePopupPointMove((physical + magic).ToString(), positionPopup);
        }
        
        private float BoostAttack(float value, List<Elements> elements)
        {
            if(value <= 0) return 0;
            foreach(Elements element in elements)
            {
               value = BoostAttackValue(value, element);
            }

            return value;
        }

        private float BoostAttackValue(float value, Elements element)
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
