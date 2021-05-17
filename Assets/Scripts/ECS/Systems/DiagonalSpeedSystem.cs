using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[AlwaysSynchronizeSystem]
public class DiagonalSpeedSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return Entities.ForEach((ref MovementData movementData) =>
        {
            if (movementData.Horizontal * movementData.Vertical != 0)
            {
                float multiplier = math.max(0, movementData.DiagonalSpeedMultiplier);

                movementData.Horizontal *= multiplier;
                movementData.Vertical *= multiplier;
            }
        }).WithBurst(FloatMode.Fast, FloatPrecision.Low)
        .Schedule(inputDeps);
    }
}
