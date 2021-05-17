using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref MovementData movementData, in PlayerInputData inputData) =>
        {
            movementData.Horizontal = movementData.Vertical = 0;

            movementData.Horizontal += Input.GetKey(inputData.MoveRight) ? 1
                                     : Input.GetKey(inputData.MoveLeft) ? -1
                                     : 0;
            movementData.Vertical   += Input.GetKey(inputData.MoveUp) ? 1
                                     : Input.GetKey(inputData.MoveDown) ? -1
                                     : 0;

            // diagonal speed
            if (movementData.Horizontal * movementData.Vertical != 0)
            {
                float multiplier = math.max(0, movementData.DiagonalSpeedMultiplier);

                movementData.Horizontal *= multiplier;
                movementData.Vertical   *= multiplier;
            }
        }).Run();

        return default;
    }
}
