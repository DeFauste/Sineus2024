using System;
using Assets.Scripts.EventMessages;
using Assets.Scripts.Spell;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MessagePipe;
using UnityEngine;
using VContainer;

public class SpellController : MonoBehaviour
{
    [SerializeField] private Transform _spellPosition;
    [SerializeField] private RuneMergeSystem _runeMergeSystem;
    [SerializeField] private RuneTransporter _runeTransporter;
    public Canvas canvas;

    protected Player.Player _player;
    protected Enemy.Enemy _enemy;
    protected ISubscriber<TurnEnded> _turnEnded;
    private IPublisher<PlayerAttackCompleted> _publisher;

    private bool _isSpellActive; 

    [Inject]
    public void Construct(Player.Player player, ISubscriber<TurnEnded> turnEnded,
        IPublisher<PlayerAttackCompleted> publisher)
    {
        _publisher = publisher;
        _player = player;
        _turnEnded = turnEnded;
        spellBuilder = new SpellBuilder();
    }

    public void Initialize(Enemy.Enemy enemy)
    {
        _enemy = enemy;
        
        spellBuilder.UpdateEnemy(_player, _enemy);
    }

    SpellBuilder spellBuilder;

    private void Start()
    {
        
        spellBuilder.LoadSpells();
        _runeMergeSystem.RunePlaced += SpellAction;
    }

    private void SpellAction()
    {
        if (_isSpellActive) return; 

        var runeType = _runeMergeSystem.GetRunes();
        CreateSpell(runeType).Forget();
    }

    private async UniTask CreateSpell(Vector2Int typeRune)
    {
        _isSpellActive = true; 

        var spell = spellBuilder.CreateSpell(typeRune);
        if (spell == null)
        {
            _publisher.Publish(new PlayerAttackCompleted());
            _isSpellActive = false; 
            return;
        }

        spell.transform.SetParent(canvas.transform, false);
        var Ispell = spell.GetComponent<ISpell>();
        spell.transform.DOMove(_spellPosition.position, 1).OnComplete(() => Ispell.DoSpell());
        await UniTask.Delay(5000);
        Destroy(spell.gameObject);

        _publisher.Publish(new PlayerAttackCompleted());

        _isSpellActive = false; 
    }

    private void OnDestroy()
    {
        _runeMergeSystem.RunePlaced -= SpellAction;
    }
}
