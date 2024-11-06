using System;
using Assets.Scripts.EventMessages;
using MessagePipe;
using VContainer;

namespace Player
{
    public class Player : Entity, IPlayerTakeDamage
    {
        private IDisposable _subscription;
        private IPublisher<PlayerDied> _playerDiedPublisher;

        [Inject]
        public void Construct(ISubscriber<TurnEnded> turnEndedSub, ISubscriber<EnemyDied> enemyDeadSubscriber,
            IPublisher<PlayerDied> playerDiedPublisher)
        {
            _playerDiedPublisher = playerDiedPublisher;
            _subscription = DisposableBag.Create(
                turnEndedSub.Subscribe(_ => OnHealthChanged()),
                enemyDeadSubscriber.Subscribe(_ => ResetHealth())
            );
        }

        private void ResetHealth()
        {
            HealthController.ResetHealth();
        }

        protected override void OnEntityDied()
        {
            base.OnEntityDied();
            Destroy(gameObject);
            _playerDiedPublisher.Publish(new PlayerDied());
        }

        public void TakeDamage(int damage, bool isAttack)
        {
            if (!isAttack)
            {
                return; // �������� ���� ��� ��� ������ �� ������� ����������
            }

            //if(Random.Range(0,100) < )
            //{
            //
            //}
            // �������� ������ �������� � �����
            HealthController.TakeDamage(damage); // �������� ������ �������� � �����
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            _subscription.Dispose();
        }
    }
}