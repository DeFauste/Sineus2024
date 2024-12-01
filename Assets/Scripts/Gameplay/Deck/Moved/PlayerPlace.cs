using Assets.Scripts.Gameplay.Card;
using Assets.Scripts.Gameplay.Deck.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
    /// <summary>
    /// Места где расскладываются карты игрока
    /// </summary>
    public class PlayerPlace : DropPlace
    {
        [SerializeField] private DillerCard _dillerCard;

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            var card = eventData.pointerDrag.GetComponent<CardBinder>();
            if (card != null)
            {
                _dillerCard._cardPlayed.Remove(card);
                _dillerCard._cardPlayer.Add(card);
            }
        }
    }
}
