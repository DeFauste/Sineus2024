namespace Assets.Scripts.Gameplay.Characters
{
    /// <summary>
    /// Все значения процентов указываются десятичным числом. К примеру 30% физ защиты  записываются как 0.3
    /// </summary>
    public struct CharacterData
    {
        public int Health; // здоровье персонажа
        public int ProtectPhysical; // физическая защита % 
        public int ProtectMagic; // магическая защита %
        public int AccuracyPhysical; // точность физических атак %
        public int AccuracyMagic ; // точность магических атак %
        public int StabilityFire ; // устойчивость к огню %
        public int StabilityEarth; // устойчивость к земле %
        public int StabilityWater; // устойчивость к воде %
        public int StabilityAir; // устойчивость к солнцу %
        public int StabilityGrief; // устойчивость к скорби %
        public int StabilitySun; // устойчивость к солнцу %
    }
}
