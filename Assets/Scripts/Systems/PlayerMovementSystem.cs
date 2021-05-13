using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class PlayerMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in PlayerMovementData movementData) =>
        {
            translation.Value.x += movementData.horizontal * movementData.speed * deltaTime;
            translation.Value.y += movementData.vertical * movementData.speed * deltaTime;
        }).Run();

        return default;
    }
}
