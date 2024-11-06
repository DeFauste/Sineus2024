using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class Valkiria : Enemy.Enemy
{
    [SerializeField] private Vector2Int _swordDamage = new Vector2Int(12,14);
    [SerializeField] private int _percentExtraDamage = 20;
    [SerializeField] private Vector2Int _curseDamage = new Vector2Int(8, 12);
    [SerializeField] private int _turnFrost = 2;
    [SerializeField] private Vector2Int _odinDamage = new Vector2Int(20, 28);
    [SerializeField] private int _percentDoubleHeal= 60;


    private GameObject PlayerGO = null;

    protected override UniTask Attack()
    {
        var percent = Random.Range(0, 100);

        if (percent >= 0 && percent <= 40)
        {
            SwordAttack();
        }
        else if (percent > 40 && percent <= 80)
        {
            CurseAttack();
        }
        else if (percent > 80)
        {
            HateOdin();
            if(Random.Range(0, 100) < _percentDoubleHeal)
            {
                ITurnSpell turnSpell = GetComponent<HealingSpellTurn>();
                turnSpell.SetTurn(1);
            }
        }

        return base.Attack();
    }

    public override void TakeDamage(int damage, Vector2Int typeDamage)
    {
        HealthController.TakeDamage(damage);//получаем урон
    }

    private void SwordAttack()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        int damage = Random.Range(_swordDamage.x, _swordDamage.y);
        if(Random.Range(0,100) < _percentExtraDamage)
        {
            damage = damage + damage * (_percentExtraDamage/100);
        }
        _player.TakeDamage(damage, isAttack);
    }
    private void CurseAttack()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        int damage = Random.Range(_swordDamage.x, _swordDamage.y);
        if (Random.Range(0, 100) < _percentExtraDamage)
        {
            damage = damage + damage * (_percentExtraDamage / 100);
        }
        _player.TakeDamage(damage, isAttack);
        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<FreezeTurn>();
        turn.SetTurn(_turnFrost);
    }

    private void HateOdin()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        int damage = Random.Range(_odinDamage.x, _odinDamage.y);
        _player.TakeDamage(damage, isAttack);
        ITurnSpell turnSpell = GetComponent<HealingSpellTurn>();
        turnSpell.SetTurn(1);

    }
}

