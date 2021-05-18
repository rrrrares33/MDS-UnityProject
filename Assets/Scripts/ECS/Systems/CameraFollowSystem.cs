using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class CameraFollowSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithAll<PlayerTag>().ForEach((FollowCameraData cameraData, in Translation playerTranslation) =>
        {
            cameraData.Value.transform.position = new Vector3(playerTranslation.Value.x, playerTranslation.Value.y, -1);
        }).WithoutBurst().Run();

        return default;
    }
}
