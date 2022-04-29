using Zenject;

public class EcsSystemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<PlayerInitSystem>()
            .FromNew()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<InputSystem>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<PlayerMovementSystem>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}