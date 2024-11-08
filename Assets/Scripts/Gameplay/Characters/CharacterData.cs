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
        public float ProtectPhysical = 0; // физическая защита % 
        public float ProtectMagic = 0; // магическая защита %
        public float AccuracyPhysical = 0; // точность физических атак %
        public float AccuracyMagic = 0; // точность магических атак %
        public float StabilityFire = 0; // устойчивость к огню %
        public float StabilityEarth = 0; // устойчивость к земле %
        public float StabilityWater = 0; // устойчивость к воде %
        public float StabilityAir = 0; // устойчивость к солнцу %
        public float StabilityGrief = 0; // устойчивость к скорби %
        public float StabilitySun = 0; // устойчивость к солнцу %
    }
}
