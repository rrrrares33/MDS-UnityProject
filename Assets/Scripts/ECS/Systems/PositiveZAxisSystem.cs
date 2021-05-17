using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class PositiveZAxisSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref Translation translation) =>
        {
            translation.Value.z = math.max(0, translation.Value.z);
        }).Run();

        return default;
    }
}
