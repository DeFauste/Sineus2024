using System;
using TMPro;
using UnityEngine;

public class PlayerHealthControllerView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _contLives;
    private Player.Player _player;

    public void Initialize(Player.Player player)
    {
        _player = player;
        _contLives.text = player.HealthController.Health.ToString();
        _player.HealthController.HealthChanged += UpdateCountLives;
    }

    private void UpdateCountLives()
    {
       _contLives.text = _player.HealthController.Health.ToString();
    }
    private void OnDestroy()
    {
        _player.HealthController.HealthChanged -= UpdateCountLives;
    }

    
}