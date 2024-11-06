using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class RuneMergeSystem : MonoBehaviour
{
    public event Action RunePlaced;
    private Rune _firstRune;
    private Rune _secondRune;
    private int _currentRune;

    private bool _isMerging ; 

    public void SetRune(Rune rune, int currentRune)
    {
        if (_isMerging) return; 

        switch (currentRune)
        {
            case 1:
                _firstRune = rune;
                break;
            case 2:
                _secondRune = rune;
                break;
        }
    }

    public Vector2Int GetRunes()
    {
        return new Vector2Int((int)_firstRune.Element, (int)_secondRune.Element);
    }

    public async UniTask MergeRunes()
    {
        if (_firstRune == null || _secondRune == null)
        {
            Debug.LogWarning("One or both runes are null, cannot merge.");
            return;
        }

        await UniTask.Delay(1500);
        
        if (_firstRune != null)
        {
            _firstRune.transform.DOMove(transform.position, 1);
        }

        if (_secondRune != null)
        {
            _secondRune.transform.DOMove(transform.position, 1).OnComplete(() => RunePlaced?.Invoke());
        }

        await UniTask.Delay(2000);
        
        if (_firstRune != null)
        {
            Destroy(_firstRune.gameObject);
        }

        if (_secondRune != null)
        {
            Destroy(_secondRune.gameObject);
        }
    }

}