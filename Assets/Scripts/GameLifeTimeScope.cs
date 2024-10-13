using Assets.Scripts.EventMessages;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private RunesController _runesController;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_player).AsSelf().AsImplementedInterfaces();
        builder.RegisterInstance(_runesController);

        RegisterMessagePipe(builder);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe();
        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

        builder.RegisterMessageBroker<PlayerAttackCompleted>(options);
        builder.RegisterMessageBroker<EnemyAttackCompleted>(options);
        builder.RegisterMessageBroker<EnemyDied>(options);
        builder.RegisterMessageBroker<TurnEnded>(options);
        builder.RegisterMessageBroker<Rune>(options);
        builder.RegisterMessageBroker<PlayerDied>(options);
    }
}