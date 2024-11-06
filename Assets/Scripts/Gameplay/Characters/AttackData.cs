using System.Collections.Generic;

namespace Assets.Scripts.Gameplay.Characters
{
    public class AttackData
    {
        public int MagicValue { get; set; }
        public int PhysicalValue { get; set; }
        public List<Elements> MagicElements { get; private set; }
        public List<Elements> PhysicalElements { get; private set; }
        public AttackData(int magicValue,int physicalValue, List<Elements> magicElements = null, List<Elements> physicalElements = null)
        {
            MagicValue = magicValue;
            PhysicalValue = physicalValue;
            MagicElements = magicElements;
            PhysicalElements = physicalElements;
        }
    }
}
