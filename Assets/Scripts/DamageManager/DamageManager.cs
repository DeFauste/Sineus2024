using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using VContainer;
using System.Threading;

public class DamageManager : MonoBehaviour
{
  // [SerializeField] private int _damageDelay = 2000;

  // [Inject] private IPlayerTakeDamage _player;
  // [Inject] private IEnemyTakeDamage _enemy;

  // private IPublisher<PlayerAttackCompleted> _playerAttackCompletedPublisher;
  // private IPublisher<EnemyAttackCompleted> _enemyAttackCompletedPublisher;
  // private IDisposable _subscription;
  // 
  // private CancellationTokenSource _cancellationTokenSource;
  // 

  // [Inject]
  // public void Construct(IPublisher<PlayerAttackCompleted> playerAttackCompletedPublisher,
  //     IPublisher<EnemyAttackCompleted> enemyAttackCompletedPublisher, ISubscriber<EnemyDied> enemyDiedSubscriber)
  // {
  //     _enemyAttackCompletedPublisher = enemyAttackCompletedPublisher;
  //     _playerAttackCompletedPublisher = playerAttackCompletedPublisher;
  //     _cancellationTokenSource = new CancellationTokenSource();
  //     _subscription = enemyDiedSubscriber.Subscribe(_ => OnEnemyDeath());
  // }

  // private async UniTask DealDamageToPlayer(CancellationToken token)
  // {
  //     try
  //     {
  //         await UniTask.Delay(_damageDelay, cancellationToken: token);
  //         _player.TakeDamage();
  //         _enemyAttackCompletedPublisher.Publish(new EnemyAttackCompleted());
  //     }
  //     catch (OperationCanceledException)
  //     {
  //         Debug.Log("Damage to player was canceled.");
  //     }
  // }

  // private void OnEnemyDeath()
  // {
  //     _cancellationTokenSource.Cancel();
  // }

  // [UsedImplicitly]
  // public void DealDamageToEnemy()
  // {
  //     _enemy.TakeDamage();
  //     _playerAttackCompletedPublisher.Publish(new PlayerAttackCompleted());

  //     DealDamageToPlayer(_cancellationTokenSource.Token).Forget();
  // }

  // private void OnDestroy()
  // {
  //     _subscription.Dispose();
  // }
}