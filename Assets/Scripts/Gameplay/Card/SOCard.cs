using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Card
{
    [CreateAssetMenu(fileName = "NewRune", menuName = "Gameplay/Card", order = 1)]
    public class SOCard : ScriptableObject
    {
        public string Name = "Rune";
        public List<Elements> Elements;
        public Sprite Sprite;
        public string Description = "Rune description";
    }
}
