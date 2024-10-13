using System;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Button _attackButton;
    private IDisposable _subscriptions;

    public void Initialize(ISubscriber<PlayerAttackCompleted> playerAttackCompletedSubscriber,
        ISubscriber<EnemyAttackCompleted> enemyAttackCompletedSubscriber)
    {
        _subscriptions = DisposableBag.Create(playerAttackCompletedSubscriber.Subscribe(
                _ => ButtonInteractableDisable()),
            enemyAttackCompletedSubscriber.Subscribe(_ => ButtonInteractableEnable()));
    }

    private void ButtonInteractableDisable()
    {
        _attackButton.interactable = false;
    }

    private void ButtonInteractableEnable()
    {
        _attackButton.interactable = true;
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}