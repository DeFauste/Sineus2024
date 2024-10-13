using Assets.Scripts.EventMessages;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Spell
{
    public class Testing: MonoBehaviour
    {

        public Canvas canvas;

        public Vector2Int testType = new Vector2Int(0, 0);

        protected Player.Player _player;
        protected Enemy.Enemy _enemy;
        protected ISubscriber<TurnEnded> _publisher;


        [Inject]
        public void Cunstruct(Player.Player player, Enemy.Enemy enemy, ISubscriber<TurnEnded> publisher)
        {
            _enemy = enemy;
            _player = player;
            _publisher = publisher;
        }

        SpellBuilder spellBuilder;

        private void Start()
        {
            spellBuilder.LoadSpells();
        }
        public void Create()
        {
            var card = spellBuilder.CreateSpell(testType);
            card.transform.SetParent(canvas.transform, false);
            ISpell i = card.GetComponent<ISpell>();
            i.DoSpell();
        }


    }


    //class TickDamage: MonoBehaviour
    //{
    //    bool isActive = false;
    //    int turn = 2;
    //    subscrive;
    //
    //        private void Start()
    //    {
    //        SubscriberExtensions += DO();
    //    }
    //    private void DO()
    //    {
    //        //Наносим урон
    //        turn -= 1;
    //        if (turn == 0)
    //        {
    //            Destroy(this);
    //        }
    //    }
    //}
}
