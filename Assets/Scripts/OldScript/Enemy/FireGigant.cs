using Assets.Scripts.Spell.SpellTurn;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class FireGigant : Enemy.Enemy
{
    [SerializeField] private int _DamageFireSpell = 8;
    [SerializeField] private int _turnDamageFireSpell = 3;
    [SerializeField] private int _shieldDamage = 10;
    [SerializeField] private Vector2Int _DamageMagma = new Vector2Int(25,28);

    private bool _shieldVoulcano = false;

    private GameObject PlayerGO = null;

    protected override UniTask Attack()
    {
        var percent = Random.Range(0, 100);

        if (percent >= 0 && percent <= 40)
        {
            SpellFire();
        }
        else if (percent > 40 && percent <= 80)
        {
            ShieldVolcano();
        }
        else if (percent > 80)
        {
            Magma();
        }

        return base.Attack();
    }

    public override void TakeDamage(int damage, Vector2Int typeDamage)
    {
      // if (typeDamage.x == (int)_typeEnemy || typeDamage.y == (int)_typeEnemy) return; // не наносим урон так как совпадают стихии
      // if (typeDamage.x == (int)_resistElement || typeDamage.y == (int)_resistElement)
      // {
      //     damage = damage + damage * (_percentResist / 100); // увеличиваем урон от уязвимой стихии
      // }
      // if(_shieldVoulcano)
      // {
      //     _player.TakeDamage(_shieldDamage, true);
      //     _shieldVoulcano = false ;
      //     return; // не наносим урон так как щит
      // }
      // damage = damage - damage * (_stateController.Shield / 100); // используем щит
        HealthController.TakeDamage(damage);//получаем урон
    }

    private void SpellFire()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        _player.TakeDamage(_DamageFireSpell, isAttack);
        if (isAttack == false) return; //ненаносим дебафов так как промах
        if (PlayerGO == null)
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        ITurnSpell turn = PlayerGO.GetComponent<FireSpellTurn>();
        turn.SetTurn(_turnDamageFireSpell);
    }

    private void ShieldVolcano()
    {
        _shieldVoulcano = true;
    }
    private void Magma()
    {
        var isAttack = true;
        if (Random.Range(0, 100) < _stateController.Distraction)
        {
            isAttack = false;
        }
        _player.TakeDamage(Random.Range(_DamageMagma.x, _DamageMagma.y), isAttack);
    }
}

