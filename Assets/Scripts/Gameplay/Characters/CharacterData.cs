using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Characters
{
    /// <summary>
    /// Проценты указываем в виде десятичного числа => 0.3
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacterData", menuName = "Gameplay/CharacterData",order = 1)]
    public class CharacterData : ScriptableObject
    {
        public string Name = "Name";
        public RuntimeAnimatorController Animation;
        public int Health = 1; // здоровье персонажа
        public float ProtectPhysical = 1; // физическая защита % 
        public float ProtectMagic = 1; // магическая защита %
        public float AccuracyPhysical = 1; // точность физических атак %
        public float AccuracyMagic = 1; // точность магических атак %
        public float StabilityFire = 1; // устойчивость к огню %
        public float StabilityEarth = 1; // устойчивость к земле %
        public float StabilityWater = 1; // устойчивость к воде %
        public float StabilityAir = 1; // устойчивость к солнцу %
        public float StabilityGrief = 1; // устойчивость к скорби %
        public float StabilitySun = 1; // устойчивость к солнцу %
    }
}
