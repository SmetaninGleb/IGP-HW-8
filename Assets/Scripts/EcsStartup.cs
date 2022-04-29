using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

sealed class EcsStartup : MonoBehaviour
{
    [Inject] private EcsSystems _systems;
    [Inject] private PlayerInitSystem _playerInitSystem;
    [Inject] private InputSystem _inputSystem;
    [Inject] private PlayerMovementSystem _playerMovementSystem;

    void Start()
    {
        _systems
            .Add(_playerInitSystem)
            .Add(_inputSystem)
            .Add(_playerMovementSystem)
                .Init();
    }

    void Update()
    {
        _systems?.Run();
    }

    void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            // add here cleanup for custom worlds, for example:
            // _systems.GetWorld ("events").Destroy ();
            _systems.GetWorld().Destroy();
            _systems = null;
        }
    }
}