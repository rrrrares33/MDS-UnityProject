using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class Physics2DSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return Entities.WithAll<PhysicsMass>().ForEach((ref Rotation rotation, ref Translation translation) =>
        {
            rotation.Value = quaternion.identity;

            if (translation.Value.z != 0)
            {
                translation.Value.z = 0;
            }
        }).WithBurst(FloatMode.Fast, FloatPrecision.Low)
        .Schedule(inputDeps);
    }
}
