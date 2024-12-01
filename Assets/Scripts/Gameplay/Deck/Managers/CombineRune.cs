using Assets.Scripts.Gameplay.Characters;
using Assets.Scripts.Gameplay.Spell;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Gameplay.Card;
using Assets.Scripts.Gameplay.Card.CardSpell;
using static Assets.Scripts.Gameplay.LevelManager;

namespace Assets.Scripts.Gameplay.Deck.Managers
{
    public class CombineRune: MonoBehaviour
    {
        [SerializeField] private DillerCard _dillerCard;
        [SerializeField] private BaseCharacter _player;
        [SerializeField] private BaseCharacter _enemy;
        [SerializeField] private LevelManager _levelManager;
        //public CombineRune(DillerCard dillerCard) 
        //{ 
        //    _dillerCard = dillerCard;
        //}
        
        private void Start()
        {
            Init();
            _levelManager.NextStep += ActivetedMerge;
        }
        /// <summary>
        /// Удалить после
        /// </summary>
        private Dictionary<List<Elements>, BaseCardSpell> _spelsDict = new ();
        private void Init()
        {
            StreamFireCardSpell streamFireCardSpell = new StreamFireCardSpell(_player, _enemy);
            _spelsDict.Add(streamFireCardSpell.GetElementList(), streamFireCardSpell);
        }
        private void ActivetedMerge(Step step)
        {
            if (step != Step.EndTurn) return;

            MergeRune();
            _dillerCard.DestroyCardPlaed();
            _levelManager.NextStep?.Invoke(Step.Player);
        }
        public void MergeRune()
        {
            List<Elements> rElements = new List<Elements> ();
            foreach(var card in _dillerCard._cardPlayed)
            {
                rElements.AddRange(card.GetCard().Elements);
            }
            rElements.Distinct();

            if (rElements.Count > 0)
            {

                foreach (var element in _spelsDict.Keys)
                {
                    bool allExist =  rElements.Count == element.Count && rElements.All(item => element.Contains(item));
                    if (allExist)
                    {
                        Debug.Log("Нашёл");
                        var cardSpel = _spelsDict[element].GetSpells();
                        foreach(var card in cardSpel)
                        {
                            card.Interact();
                        }
                    }
                }
            }
        }
    }
}
