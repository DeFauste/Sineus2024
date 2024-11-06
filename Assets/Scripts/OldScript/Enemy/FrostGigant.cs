using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class FrostGigant : Enemy.Enemy
{
    [SerializeField] private Vector2Int _stoneDamage = new Vector2Int(12,17);
    [SerializeField] private Vector2Int _stormDamage = new Vector2Int(17,19);
    [SerializeField] private int _healing = 20;
    [SerializeField] private int _turnFrost = 1;
    private GameObject PlayerGO = null;

    protected override UniTask Attack()
    {
        var percent = Random.Range(0, 100);

        if (percent >= 0 && percent <= 40)
        {
            StoneSpell();
        }
        else if (percent > 40 && percent <= 80)
        {
            FreezeSpell();
        }
        else if (percent > 80)
        {
            Storm();
        }

        return base.Attack();
    }

    public override void TakeDamage(int damage, Vector2Int typeDamage)
    {
        if (typeDamage.x == (int)_typeEnemy || typeDamage.y == (int)_typeEnemy) return; // не наносим урон так как совпадают стихии
        if (typeDamage.x == (int)_resistElement || typeDamage.y == (int)_resistElement)
        {
            damage = damage + damage * (_percentResist / 100); // увеличиваем урон от уязвимой стихии
        }
        damage = damage - damage * (_stateController.Shield / 100); // используем щит
        HealthController.TakeDamage(damage);//получаем урон
    }

    private void StoneSpell()
    {
        var damage = Random.Range(_stoneDamage.x, _stoneDamage.y);
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Blinding)
        {
            isAttack = false;
        }
        _player.TakeDamage(damage, isAttack);
    }

    private void FreezeSpell()
    {
        var heal = GetComponent<HealingSpellTurn>();
        heal.SetTurn(1);
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<FreezeTurn>();
        turn.SetTurn(_turnFrost);
        
    }

    private void Storm()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        _player.TakeDamage(Random.Range(_stoneDamage.x, _stoneDamage.y), isAttack);
        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<FreezeTurn>();
        turn.SetTurn(_turnFrost);
    }
}

