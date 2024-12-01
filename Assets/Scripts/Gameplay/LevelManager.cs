using System;
using UnityEngine;
using UnityEngine.UI;
using R3;
namespace Assets.Scripts.Gameplay
{
    public class LevelManager: MonoBehaviour
    {
        public Action<Step> NextStep;
        [SerializeField] private Button _nextTurn;
        public enum Step
        {
            Wait,
            Player,
            Enemy,
            EndTurn
        }

        public void Start()
        {
            NextStep += ActiveButton;
            NextStep?.Invoke(Step.Player);
            _nextTurn.OnClickAsObservable().Subscribe(_ => TurnButton()).AddTo(this);
        }
        private void ActiveButton(Step step)
        {
            _nextTurn.interactable = step == Step.Player;
        }
        private void TurnButton()
        {
            NextStep?.Invoke(Step.EndTurn);
        }
    }
}
