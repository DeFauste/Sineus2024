using Assets.Scripts.Gameplay.Card;
using Assets.Scripts.Gameplay.Deck.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
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
