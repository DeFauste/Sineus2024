using System;
using DG.Tweening;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerHealthControllerView _playerHealthControllerView;
    [SerializeField] private EnemyHealthControllerView _enemyHealthControllerView;
    [SerializeField] private Image _gameOverScene;
    private Player.Player _player;
    private IDisposable _subscriptions;
    


    [Inject]
    public void Construct(Player.Player player, ISubscriber<PlayerDied> subscriber)
    {
       
        _player = player;
        _subscriptions = subscriber.Subscribe(_ => ShowDeadScreen());
    }

    private void ShowDeadScreen()
    {
        _gameOverScene.transform.DOLocalMove(new Vector3(11, 5, 0), 1);
    }

    private void Awake()
   {
       _playerHealthControllerView.Initialize(_player);
      // _enemyHealthControllerView.Initialize(_enemy);
   }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}