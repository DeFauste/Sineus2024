using Assets.Scripts.Gameplay.Characters;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Ability
{
    public class HealAbility : Ability
    {
        public HealAbility(CharacterData playerData, CharacterData enemyData) : base(playerData, enemyData)
        {
        }

        public override void Activate()
        {
            Debug.Log("Хиииил");
        }
    }
}
