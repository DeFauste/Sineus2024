using VContainer;
using VContainer.Unity;

public class DeadLifeTimeScope : LifetimeScope
{
    private ScenesController _scenesController;
    protected override void Awake()
    {
        _scenesController = FindObjectOfType<ScenesController>();
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    protected override void Configure(IContainerBuilder builder)
    {
       
    }
}