using Assets.Scripts.Gameplay.Card;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Scripts.Gameplay.Deck.Managers
{
    public class CardManager
    {
        private SOCardLibrary _card;
        public CardManager(SOCardLibrary cardLib)
        {
            _card = cardLib;
        }

        private List<SOCard> GetAllCards() => _card.cards.ToList();
        public SOCard GetRandomCard()
        {
            int rnd = Random.Range(0, _card.cards.Count);
            return _card.cards[rnd];
        }
        public List<SOCard> GetRandomCards(int count)
        {
            return Enumerable.Range(0, count)
                   .Select(_ => GetRandomCard())
                   .ToList();
        }
    }
}
