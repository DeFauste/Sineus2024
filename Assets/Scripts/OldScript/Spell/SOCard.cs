using UnityEngine;

namespace Assets.Scripts.Spell
{
    [CreateAssetMenu(fileName = "NewCardSpell", menuName = "ScriptableObjects/CreateCardSpell", order = 1)]
    public class SOCard : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Image;
    }
}
