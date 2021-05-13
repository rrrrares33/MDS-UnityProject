using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref PlayerMovementData movementData, in PlayerInputData inputData) =>
        {
            movementData.horizontal = movementData.vertical = 0;

            movementData.horizontal += Input.GetKey(inputData.rightKey) ? 1
                                     : Input.GetKey(inputData.leftKey) ? -1
                                     : 0;
            movementData.vertical += Input.GetKey(inputData.upKey) ? 1
                                     : Input.GetKey(inputData.downKey) ? -1
                                     : 0;

            // decrease diagonal movement speed
            if (movementData.horizontal * movementData.vertical != 0)
            {
                float speedDecrease = math.clamp(movementData.diagonalSpeedDecrease, 0, 1);
                movementData.horizontal *= speedDecrease;
                movementData.vertical *= speedDecrease;
            }
        }).Run();

        return default;
    }
}
