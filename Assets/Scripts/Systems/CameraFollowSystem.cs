using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class CameraFollowSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithAll<PlayerTag>().ForEach((CameraFollowData cameraData, in Translation translation) =>
        {
            cameraData.Value.transform.position = new Vector3(translation.Value.x, translation.Value.y, -1);
        }).WithoutBurst().Run();

        return default;
    }
}
