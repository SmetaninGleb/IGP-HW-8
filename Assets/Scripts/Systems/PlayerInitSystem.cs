using Leopotam.EcsLite;

sealed class PlayerInitSystem : IEcsInitSystem
{
    private PlayerView _playerView;
    private PlayerMovementConfig _movementConfig;

    public PlayerInitSystem(PlayerView playerView, PlayerMovementConfig movementConfig)
    {
        _playerView = playerView;
        _movementConfig = movementConfig;
    }

    public void Init(EcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        int entity = world.NewEntity();
        EcsPool<PlayerComponent> playerPool = world.GetPool<PlayerComponent>();
        ref PlayerComponent playerComponent = ref playerPool.Add(entity);
        playerComponent.Player = _playerView;
        playerComponent.CurrentDirectionIndex = _movementConfig.StartDirectionIndex;
        int currentDirInd = playerComponent.CurrentDirectionIndex;
        playerComponent.MovingDirection = _movementConfig.Directions[currentDirInd];
    }
}
