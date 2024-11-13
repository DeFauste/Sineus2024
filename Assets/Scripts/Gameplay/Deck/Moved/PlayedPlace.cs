using Assets.Scripts.Gameplay.Card;
using Assets.Scripts.Gameplay.Deck.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
    public class PlayedPlace : DropPlace
    {
        [SerializeField] private DillerCard _dillerCard;
        public override void OnDrop(PointerEventData eventData)
        {
            if(_dillerCard._cardPlayed.Count < 2) { 
                base.OnDrop(eventData);
                var card = eventData.pointerDrag.GetComponent<CardBinder>();
                if (card != null)
                {
                    _dillerCard._cardPlayed.Add(card);
                    _dillerCard._cardPlayer.Remove(card);
                }
            }
        }
    }
}
