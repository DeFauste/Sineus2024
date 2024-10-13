using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Warvar : Enemy.Enemy
{
    [SerializeField] private int PercentDodge = 22;
    [SerializeField] private Vector2Int _spellAxe;
    [SerializeField] private int _spellBitWolf;
    [SerializeField] private int _turnBleending;
    [SerializeField] private Vector2Int _spellTrhowStone;
    [SerializeField] private int _percentBashStone;
    [SerializeField] private int _turnBash;

    private GameObject PlayerGO = null;
    private void Start()
    {
        _stateController.Dodge = PercentDodge;
    }

    protected override UniTask Attack()
    {
        var percent = Random.Range(0, 100);

        if(percent >= 0 && percent <= 40)
        {
            SpellAxe();
        } else if(percent >40 && percent <= 80)
        {
            SpellBitWolf();
        }else if (percent > 80)
        {
            SpellThrowStone();
        }

        return base.Attack();
    }

    public override void TakeDamage(int damage, Vector2Int typeDamage)
    {
        Debug.Log("Varvar");
        if (!_stateController.IsBash && UnityEngine.Random.Range(0, 100) < _stateController.Dodge) return; // уклонаемся
        HealthController.TakeDamage(damage);//получаем урон
    }

    private void SpellAxe()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        int damage = Random.Range(_spellAxe.x, _spellAxe.y);
        _player.TakeDamage(damage, isAttack);
    }

    private void SpellBitWolf()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        _player.TakeDamage(_spellBitWolf, isAttack);
        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<BleendingTurn>();
        turn.SetTurn(_turnBleending);
    }

    private void SpellThrowStone()
    {
        var damage = Random.Range(_spellTrhowStone.x, _spellTrhowStone.y);
        var isAttack = true;
        if (Random.Range(0,100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        _player.TakeDamage(damage, isAttack);
        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        if(Random.Range(0,100) < _percentBashStone)
        {
            ITurnSpell turn = PlayerGO.GetComponent<BashSpellTurn>();
            turn.SetTurn(_turnBash);
        }
    }

}

