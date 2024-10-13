using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LobbyLifeTimeScope : LifetimeScope
{
    [SerializeField] private ScenesController _scenesController;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_scenesController);
    }
}