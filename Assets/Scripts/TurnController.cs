using Assets.Scripts.EventMessages;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Assets.Scripts
{
    public class TurnController: MonoBehaviour
    {
        IPublisher<TurnEnded> _turnEnded;

        [Inject]
        public void Consrtruct(IPublisher<TurnEnded> turnEnded)
        {
            _turnEnded = turnEnded;
        }

        public void NextTurn()
        {
            _turnEnded.Publish(new TurnEnded());
        }

    }
}
