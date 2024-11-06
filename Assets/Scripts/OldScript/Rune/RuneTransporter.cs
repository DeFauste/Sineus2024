using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using MessagePipe;
using VContainer;

public class RuneTransporter : MonoBehaviour
{
    public event Action<Rune, int> RuneFound;
    public event Action StartCreateSpell;

    [SerializeField] private Transform _firstPlace;
    [SerializeField] private Transform _secondPlace;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    [SerializeField] private RuneSlotManager _runeSlotManager;

    private IDisposable _subscriptions;

    private int _foundRunesCount;
    private bool _isActive = true;
    private readonly int _countCardsForMerge = 2;

    [Inject]
    public void Construct(ISubscriber<EnemyAttackCompleted> subscriber)
    {
        _subscriptions = subscriber.Subscribe(_ => ActivateScript());
    }
    
    private void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var pointerData = new PointerEventData(_eventSystem)
            {
                position = Input.mousePosition
            };

            var results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(pointerData, results);

            foreach (var result in results)
            {
                if (result.gameObject.CompareTag(GlobalConstants.RUNE))
                {
                    _foundRunesCount++;
                    var runeTransform = result.gameObject.GetComponent<RectTransform>();
                    var rune = GetRune(result);

                    if (runeTransform != null)
                    {
                        var previousSlotIndex = _runeSlotManager.GetRuneSlotIndex(runeTransform);
                        _runeSlotManager.FreeSlot(previousSlotIndex);

                        MoveRune(runeTransform);
                    }

                    RuneFound?.Invoke(rune, _foundRunesCount);
                }
            }
        }
    }
    private void ActivateScript()
    {
        _isActive = true;
        _foundRunesCount = 0;
    }

    private void MoveRune(RectTransform runeTransform)
    {
        runeTransform.DOMove(_foundRunesCount == 1 ? _firstPlace.position : _secondPlace.position, 1f)
            .OnComplete(() =>
            {
                if (_foundRunesCount == _countCardsForMerge)
                {
                    StartCreateSpell?.Invoke();
                    _isActive = false;
                }
            });
    }

    private Rune GetRune(RaycastResult result)
    {
        return result.gameObject.GetComponent<Rune>();
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}
