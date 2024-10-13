using Assets.Scripts.EventMessages;
using MessagePipe;
using System;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Spell.SpellTurn
{
    public class BaseSpellTurn : MonoBehaviour, ITurnSpell
    {
        protected int turnCount = 0;
        protected bool isActive = false;
        protected IDisposable _dispose;
        protected Entity _entity;

        [Inject]
        public void Construct(ISubscriber<TurnEnded> subscriber)
        {
            _dispose = subscriber.Subscribe(_ => DoTick());
        }
        private void Start()
        {
            _entity = GetComponent<Entity>();
        }
        public void ClearTurn()
        {
            turnCount = 0;
            isActive = false;
        }

        public virtual void SetTurn(int turn)
        {
            turnCount += turn;
            isActive = true;
        }

        public virtual void DoTick()
        {
 
        }
        private void OnDestroy()
        {
            _dispose?.Dispose();
        }
    }
}
