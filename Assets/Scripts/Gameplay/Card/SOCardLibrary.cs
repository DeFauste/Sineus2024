using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Card
{
    [CreateAssetMenu(fileName = "NewLibrary", menuName = "Gameplay/Library", order = 1)]
    public class SOCardLibrary : ScriptableObject
    {
        public List<SOCard> cards;
    }
}
