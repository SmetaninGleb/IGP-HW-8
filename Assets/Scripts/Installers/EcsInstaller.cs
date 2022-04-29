using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class EcsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<EcsWorld>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<EcsSystems>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}