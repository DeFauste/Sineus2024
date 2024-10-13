using System;
using TMPro;
using UnityEngine;

public class EnemyHealthControllerView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _contLives;
    private Enemy.Enemy _enemy;

    public void Initialize(Enemy.Enemy enemy)
    {
        _enemy = enemy;
        _contLives.text = enemy.HealthController.Health.ToString();
        _enemy.HealthController.HealthChanged += UpdateCountLives;
    }
    private void UpdateCountLives()
    {
        _contLives.text = _enemy.HealthController.Health.ToString();
    }

    private void OnDestroy()
    {
        _enemy.HealthController.HealthChanged -= UpdateCountLives;
    }
}