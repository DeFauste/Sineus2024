using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Drauge : Enemy.Enemy
{
    [SerializeField] private int _percentRezistDamage = 22;
    [SerializeField] private Vector2Int _spellOneDamage = new Vector2Int(12,14);
    [SerializeField] private Vector2Int _spellTWoDamage = new Vector2Int(13,15);
    [SerializeField] private int _turnBash = 1;
    [SerializeField] private int _turnBashSpelThree = 2;
    [SerializeField] private int _turnBlinfing = 2;
    [SerializeField] private int _turnFire = 2;

    private GameObject PlayerGO = null;

    protected override UniTask Attack()
    {
        var percent = Random.Range(0, 100);

        if (percent >= 0 && percent <= 40)
        {
            SpellOne();
        }
        else if (percent > 40 && percent <= 80)
        {
            SpellTwo();
        }
        else if (percent > 80)
        {
            SpellThree();
        }

        return base.Attack();
    }

    public override void TakeDamage(int damage, Vector2Int typeDamage)
    {
        damage = damage - damage * (_percentRezistDamage / 100);
        HealthController.TakeDamage(damage);//получаем урон
    }

    private void SpellOne()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        _player.TakeDamage(Random.Range(_spellOneDamage.x, _spellOneDamage.y), isAttack);

        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<BleendingTurn>();
        turn.SetTurn(_turnBlinfing);
        turn = PlayerGO.GetComponent<BashSpellTurn>();
        turn.SetTurn(_turnBash);
        turn = PlayerGO.GetComponent<FireSpellTurn>();
        turn.SetTurn(_turnFire);
    }

    private void SpellTwo()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        var damage = Random.Range(_spellTWoDamage.x, _spellTWoDamage.y);
        _player.TakeDamage(damage, isAttack);

        if (isAttack == false) return; //ненаносим дебафов так как промах
        HealthController.AddHealth(damage);
    }

    private void SpellThree()
    {
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<BashSpellTurn>();
        turn.SetTurn(_turnBashSpelThree);
    }

}

