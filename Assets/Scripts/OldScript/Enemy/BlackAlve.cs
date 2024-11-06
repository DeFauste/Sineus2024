using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class BlackAlve :Enemy.Enemy
{
    [SerializeField] private Vector2Int _spellOneDamage = new Vector2Int(22, 24);
    [SerializeField] private int _turnBlinding = 3;
    [SerializeField] private int _turnPoison = 3;
    [SerializeField] private int _turnBash = 1;
    [SerializeField] private int _turnHeal= 1;

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
        if (typeDamage.x == (int)_typeEnemy || typeDamage.y == (int)_typeEnemy) return; // не наносим урон так как совпадают стихии
        if (typeDamage.x == (int)_resistElement || typeDamage.y == (int)_resistElement)
        {
            damage = damage + damage * (_percentResist / 100); // увеличиваем урон от уязвимой стихии
        }
        damage = damage - damage * (_stateController.Shield / 100); // используем щит
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
        turn.SetTurn(_turnBlinding);
    }
    private void SpellTwo()
    {
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<PoisonTurn>();
        turn.SetTurn(_turnPoison);
    }
    private void SpellThree()
    {
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<BaseSpellTurn>();
        turn.SetTurn(_turnBash);
        turn = GetComponent<HealingSpellTurn>();
        turn.SetTurn(_turnHeal);
    }
}

