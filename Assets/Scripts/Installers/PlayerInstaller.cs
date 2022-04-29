using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerSpawn _playerSpawn;
    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerMovementConfig>()
            .FromInstance(_playerMovementConfig)
            .AsSingle();

        PlayerView playerInstance = Container.InstantiatePrefabForComponent<PlayerView>
            (_playerPrefab, 
            _playerSpawn.transform.position, 
            _playerSpawn.transform.rotation, 
            null);

        Container
            .Bind<PlayerView>()
            .FromInstance(playerInstance)
            .AsSingle()
            .NonLazy();
    }
}