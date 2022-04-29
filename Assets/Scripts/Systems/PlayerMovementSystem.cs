using Leopotam.EcsLite;
using UnityEngine;

sealed class PlayerMovementSystem : IEcsRunSystem
{
    private PlayerMovementConfig _config;

    public PlayerMovementSystem(PlayerMovementConfig movementConfig)
    {
        _config = movementConfig;
    }

    public void Run(EcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        EcsFilter inputFilter = world.Filter<InputSignal>().End();
        EcsFilter playerFilter = world.Filter<PlayerComponent>().End();
        EcsPool<PlayerComponent> playerPool = world.GetPool<PlayerComponent>();
        foreach (int entity in playerFilter)
        {
            ref PlayerComponent player = ref playerPool.Get(entity);
            if (inputFilter.GetEntitiesCount() != 0)
            {
                player.CurrentDirectionIndex++;
                player.CurrentDirectionIndex %= _config.Directions.Count;
                int dirIndex = player.CurrentDirectionIndex;
                player.MovingDirection = _config.Directions[dirIndex];
            }
            player.Player.transform.position += player.MovingDirection.normalized * _config.Speed * Time.deltaTime;
        }
    }
}