using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref MovementData movementData, in PlayerInputData inputData) =>
        {
            movementData.Horizontal = Input.GetKey(inputData.MoveRight) ? 1
                                    : Input.GetKey(inputData.MoveLeft) ? -1
                                    : 0;
            movementData.Vertical = Input.GetKey(inputData.MoveUp) ? 1
                                  : Input.GetKey(inputData.MoveDown) ? -1
                                  : 0;
        }).WithBurst(FloatMode.Fast, FloatPrecision.Low)
        .Run();

        return default;
    }
}
