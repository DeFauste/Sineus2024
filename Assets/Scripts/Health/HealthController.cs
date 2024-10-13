using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class HealthController
{
    public event Action HealthChanged;
    public event Action Healning;
    public event Action Died;
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private float _health;
    private readonly float _maxHealth;
    private bool _isDead => Health <= 0;
    private int maxHealth = 100;

    public HealthController(float health)
    {
        _health = health;
        _maxHealth = _health;
    }
    public void AddHealth(int value)
    {
        _health += value;
        Debug.Log("добавили здоровье");
        Healning?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (_isDead)
        {
            return;
        }
        if (damage >= _health)
        {
            _health = 0;
        }
        else
        {
            _health -= damage;
        }

        HealthChanged?.Invoke();
        if (_health == 0)
        {
            Died?.Invoke();
        }
    }

    public void ResetHealth()
    {
        _health = maxHealth;
        
    }
}