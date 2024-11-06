using System;
using System.Collections.Generic;
using Assets.Scripts.EventMessages;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MessagePipe;
using UnityEngine;
using VContainer;

public class RuneSlotManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _places;
    private List<bool> _availablePlaces;
    [SerializeField] private RunesProvider _runesProvider;
    private IDisposable _subscription;
    private bool _enemyIsDead;

    [Inject]
    public void Construct(ISubscriber<EnemyAttackCompleted> subscriber, ISubscriber<EnemyDied> enemyDiedSubscriber,
        ISubscriber<TurnEnded> turnEndedSub)
    {
        _subscription = DisposableBag.Create(
            subscriber.Subscribe(_ => SetRunes()),
            enemyDiedSubscriber.Subscribe(_ => OnEnemyDied()));

    }

    private void Awake()
    {
        InitRunes();
    }

    private void InitRunes()
    {
        InitializeAvailablePlaces();
        SetRunes();
    }

    private void InitializeAvailablePlaces()
    {
        _availablePlaces = new List<bool>();
        for (var i = 0; i < _places.Count; i++)
        {
            _availablePlaces.Add(false);
        }
    }

    private void SetRunes()
    {
        if (_enemyIsDead) return;

        for (var i = 0; i < _places.Count; i++)
        {
            if (!_availablePlaces[i])
            {
                var rune = _runesProvider.GetRandomRune();
                rune.transform.SetParent(_places[i], false);
                rune.transform.DOLocalMove(Vector2.zero, 1);

                _availablePlaces[i] = true;
            }
        }
    }

    public void FreeSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < _availablePlaces.Count)
        {
            _availablePlaces[slotIndex] = false;
            Debug.Log($"Слот {slotIndex} освобожден.");
        }
    }

    public int GetRuneSlotIndex(RectTransform runeTransform)
    {
        for (int i = 0; i < _places.Count; i++)
        {
            if (_places[i] == runeTransform.parent)
            {
                return i;
            }
        }

        return -1;
    }


    private async UniTask OnEnemyDied()
    {
        _enemyIsDead = true;
        Debug.Log("Enemy died. Destroying all runes...");
        DestroyAllRunes();  // Уничтожение рун
        await UniTask.Delay(1000);
        _enemyIsDead = false;

        if (AllRunesDestroyed()) // Проверка, если все руны действительно были уничтожены
        {
            InitRunes(); // Повторная инициализация только при необходимости
        }
    }
    private bool AllRunesDestroyed()
    {
        foreach (var place in _places)
        {
            if (place.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }


    private void DestroyAllRunes()
    {
        foreach (var place in _places)
        {
            if (place.childCount > 0)
            {
                Destroy(place.GetChild(0).gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        _subscription.Dispose();
    }
}