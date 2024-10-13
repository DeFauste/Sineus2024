using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using System.Threading;

namespace Enemy
{
    public class Enemy : Entity
    {
        private IPublisher<EnemyDied> _enemyDiedPublisher;
        private IDisposable _subscription;
        protected Player.Player _player;
        private IPublisher<EnemyAttackCompleted> _publisher;

        private CancellationTokenSource _cancellationTokenSource; 

        
        public void Initialize(IPublisher<EnemyDied> enemyDiedPublisher, ISubscriber<PlayerAttackCompleted> subscriber,
            Player.Player player, IPublisher<EnemyAttackCompleted> publisher)
        {
            _publisher = publisher;
            _player = player;
            _enemyDiedPublisher = enemyDiedPublisher;

            _subscription = subscriber.Subscribe(_ => Attack()); 
        }

        protected override void OnEntityDied()
        {
            base.OnEntityDied();

            _cancellationTokenSource?.Cancel(); 
            _enemyDiedPublisher.Publish(new EnemyDied());
            Destroy(gameObject);
        }

        protected virtual async UniTask Attack()
        {
            _cancellationTokenSource = new CancellationTokenSource(); 
            CancellationToken token = _cancellationTokenSource.Token;

            Debug.Log("attack player");
            
            try
            {
                await UniTask.Delay(2000, cancellationToken: token); 
                if (!token.IsCancellationRequested) 
                {
                    Debug.Log("Player took damage");
                    _publisher.Publish(new EnemyAttackCompleted());
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Attack was cancelled.");
            }
        }
        public override void TakeDamage(int damage, Vector2Int typeDamage)
        {
            Debug.Log("Enemy");
            if (typeDamage.x == (int)_typeEnemy || typeDamage.y == (int)_typeEnemy) return; // �� ������� ���� ��� ��� ��������� ������
            if (UnityEngine.Random.Range(0, 100) < _stateController.Dodge) return; // ����������
            if (UnityEngine.Random.Range(0, 100) < _stateController.Trick)
            {
                _player.HealthController.TakeDamage(damage);
                return;//���������� ���� ������
            }
            if(typeDamage.x == (int)_resistElement || typeDamage.y == (int)_resistElement)
            {
                damage = damage + damage * (_percentResist / 100); // ����������� ���� �� �������� ������
            }
            damage = damage - damage * (_stateController.Shield / 100); // ���������� ���
            HealthController.TakeDamage(damage);//�������� ����
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _subscription.Dispose();
            _cancellationTokenSource?.Dispose(); 
        }

        public void EnemyDied()
        {
            _enemyDiedPublisher.Publish(new EnemyDied());
            Debug.Log("EnemyDied");
        }
    }
}