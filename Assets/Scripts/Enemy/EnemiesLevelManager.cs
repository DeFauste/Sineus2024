using System;
using System.Collections.Generic;
using MessagePipe;
using UnityEditor.Animations;
using UnityEngine;
using VContainer;

public class EnemiesLevelManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bgSprite;
    [SerializeField] private List<Sprite> _bgSprites;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private EnemyHealthControllerView _enemyHealthControllerView;
     private GameObject _gameObjectEnemy;

    [SerializeField] private SpellController _spellController;
    
    private int _indexLevel;
    private IDisposable _subscribers;
    private IPublisher<EnemyDied> _enemyDiedPublisher;
    private ISubscriber<PlayerAttackCompleted> _subscriber;
    private Player.Player _player;
    private IPublisher<EnemyAttackCompleted> _publisher;

    [Inject]
    public void Construct(IPublisher<EnemyDied> enemyDiedPublisher, ISubscriber<PlayerAttackCompleted> subscriber,
        Player.Player player, IPublisher<EnemyAttackCompleted> publisher, ISubscriber<EnemyDied> enemyDiedSubscribe)
    {
        _publisher = publisher;
        _player = player;
        _subscriber = subscriber;
        _enemyDiedPublisher = enemyDiedPublisher;
        _subscribers = enemyDiedSubscribe.Subscribe(_ => UpdateEnemy());
    }

    private void Awake()
    {
        //  _enemySpriteRenderer.sprite = _enemiesSprites[_indexLevel];
        //  _enemyAnimator.runtimeAnimatorController = _enemiesAnimators[_indexLevel];
        _bgSprite.sprite = _bgSprites[_indexLevel];
        _gameObjectEnemy = Instantiate(_enemyPrefabs[_indexLevel]);
        var enemy = _gameObjectEnemy.GetComponent<Enemy.Enemy>();
        enemy.Initialize(_enemyDiedPublisher, _subscriber, _player, _publisher);
        
        _enemyHealthControllerView.Initialize(enemy);
        _spellController.Initialize(enemy);
    }

    private void UpdateEnemy()
    {
        _indexLevel++;
        if (_indexLevel > 6)
        {
            //логика победы
            return;
        }

        // _enemySpriteRenderer.sprite = _enemiesSprites[_indexLevel];
        // _enemyAnimator.runtimeAnimatorController = _enemiesAnimators[_indexLevel];
        _bgSprite.sprite = _bgSprites[_indexLevel];
        _gameObjectEnemy = Instantiate(_enemyPrefabs[_indexLevel]);
        var enemy = _gameObjectEnemy.GetComponent<Enemy.Enemy>();
        enemy.Initialize(_enemyDiedPublisher, _subscriber, _player, _publisher);
        _spellController.Initialize(enemy);
        _enemyHealthControllerView.Initialize(enemy);
    }

    private void OnDestroy()
    {
        _subscribers.Dispose();
    }
}