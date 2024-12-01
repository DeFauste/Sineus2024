using Assets.Scripts.Gameplay.Card;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.Gameplay.LevelManager;

namespace Assets.Scripts.Gameplay.Deck.Managers
{
    public class DillerCard : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private CardBinder prefCard;
        [SerializeField] private RectTransform parent;
        [SerializeField] private RectTransform _pointStartMove;
        private CardManager _cardManager;
        public List<CardBinder> _cardPlayer = new ();
        public List<CardBinder> _cardPlayed = new ();
        [SerializeField] private int _maxValueCardPlayer = 4;
        private void Awake()
        {
            var runeLib = Resources.Load<SOCardLibrary>("RunesLibrary");
            _cardManager = new CardManager(runeLib);
            levelManager.NextStep += TakeFullCard;

        }
        public void TakeFullCard(Step step)
        {
            if(step == Step.Player)
            {
                for (int i = 0; i < _maxValueCardPlayer; i++)
                {
                    TakeCard();
                }
            }

        }


        private void TakeCard()
        {
            if(_cardPlayer.Count >= _maxValueCardPlayer) return;

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
        public void DestroyCardPlaed()
        {
            foreach(var card in _cardPlayed)
            {
                if (card != null)
                {
                    Destroy(card.gameObject);
                }
            }
            _cardPlayed.Clear();

        }
    }
}
