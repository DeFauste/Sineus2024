using Assets.Scripts.Gameplay.Card;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Deck.Managers
{
    public class DillerCard : MonoBehaviour
    {
        [SerializeField] private CardBinder prefCard;
        [SerializeField] private RectTransform parent;
        [SerializeField] private RectTransform _pointStartMove;
        private CardManager _cardManager;
        private List<CardBinder> _cardPlayer = new ();
        private void Awake()
        {
            var runeLib = Resources.Load<SOCardLibrary>("RunesLibrary");
            _cardManager = new CardManager(runeLib);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                TakeCard();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                DestroyCard();
            }
        }
        private void TakeCard()
        {
           var card = _cardManager.GetRandomCard();
           var viewCard = Instantiate(prefCard, _pointStartMove, false);
           viewCard.SetCard(card);
           _cardPlayer.Add(viewCard);
            viewCard.IsInteract(false);

            viewCard.transform.DOMove(parent.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() => { 
                SetPerent(viewCard.gameObject, parent); 
                viewCard.IsInteract(true); 
            });
        }
        private void SetPerent(GameObject gameObject, RectTransform rectTransform)
        {
            gameObject.transform.SetParent(rectTransform, false);

        }
        private void DestroyCard()
        {
            var c = _cardPlayer.First();
            _cardPlayer.Remove(c);
            Destroy(c.gameObject);
        }
    }
}
