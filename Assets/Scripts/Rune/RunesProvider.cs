using System.Collections.Generic;
using UnityEngine;

public class RunesProvider : MonoBehaviour
{
   [SerializeField] private List<Rune> _runes;

   public Rune GetRandomRune()
   {
      var randomIndex = Random.Range(0, _runes.Count);
      var rune = Instantiate(_runes[randomIndex]);
      return rune;
   }
}