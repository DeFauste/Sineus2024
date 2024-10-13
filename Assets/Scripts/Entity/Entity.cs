using UnityEngine;

public abstract class Entity : MonoBehaviour, IEnemyTakeDamage
{
    [SerializeField] protected Elements _typeEnemy = Elements.Default;
    [SerializeField] protected Elements _resistElement = Elements.Default;
    [SerializeField] protected int _percentResist = 0;
    [SerializeField] public float _maxHealth = 100;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;
    public HealthController HealthController { get; set; }
    public StateController _stateController { get; set; }
    private void Awake()
    {
        HealthController = new HealthController(_maxHealth);
        _stateController = new StateController();
        SubscribeToHealthEvents();
    }
    private void SubscribeToHealthEvents()
    {
        HealthController.Died += OnEntityDied;
        HealthController.HealthChanged += OnHealthChanged;
    }
    
    protected virtual void OnHealthChanged()
    {
        Debug.Log($"{gameObject.name}: Здоровье изменилось. Текущее здоровье: {HealthController.Health}");
    }
    protected virtual void OnEntityDied()
    {
        Debug.Log($"{gameObject.name} умер.");
        
    }

    protected virtual void OnDestroy()
    {
        HealthController.Died -= OnEntityDied;
        HealthController.HealthChanged -= OnHealthChanged;
    }
    
    public virtual void TakeDamage(int damage, Vector2Int typeDamage)
    {
        
    }
}