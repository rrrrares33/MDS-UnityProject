using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class ChasePlayerSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        NativeArray<Translation> playerTranslations = GetEntityQuery(typeof(PlayerTag), typeof(Translation))
            .ToComponentDataArray<Translation>(Allocator.TempJob);

        return Entities.ForEach((ref MovementData movementData, in ChasePlayerData chaseData, in Translation translation) =>
        {
            movementData.Horizontal = movementData.Vertical = 0;

            if (playerTranslations.Length == 0)
            {
                return;
            }

            float differenceX = playerTranslations[0].Value.x - translation.Value.x;
            float differenceY = playerTranslations[0].Value.y - translation.Value.y;

            if (differenceX * differenceX + differenceY * differenceY > chaseData.StopAtDistance * chaseData.StopAtDistance)
            {
                movementData.Horizontal = math.sign(differenceX);
                movementData.Vertical = math.sign(differenceY);
            }
        }).WithDisposeOnCompletion(playerTranslations).Schedule(inputDeps);
    }
}
