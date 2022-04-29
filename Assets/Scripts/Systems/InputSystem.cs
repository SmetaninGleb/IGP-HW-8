using UnityEngine;
using Leopotam.EcsLite;
using Zenject;

sealed class InputSystem : IEcsRunSystem
{
    public void Run(EcsSystems systems)
    {
        ClearAllSignals(systems.GetWorld());
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateNewSignal(systems.GetWorld());
        }
    }

    private void CreateNewSignal(EcsWorld world)
    {
        EcsPool<InputSignal> inputPool = world.GetPool<InputSignal>();
        int signalEntity = world.NewEntity();
        inputPool.Add(signalEntity);
    }

    private void ClearAllSignals(EcsWorld world)
    {
        EcsFilter inputFilter = world.Filter<InputSignal>().End();
        EcsPool<InputSignal> inputPool = world.GetPool<InputSignal>();
        foreach (int entity in inputFilter)
        {
            inputPool.Del(entity);
        }
    }
}