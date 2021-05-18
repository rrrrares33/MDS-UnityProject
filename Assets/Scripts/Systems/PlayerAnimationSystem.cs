using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerAnimationSystem : JobComponentSystem
{
    private Animator Animator;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithAll<PlayerTag>().ForEach((AnimationData animationData, in MovementData movementData, in Translation translation) =>
        {
            if (Animator == null)
            {
                Animator = animationData.Container.GetComponent<Animator>();
            }
            Animator.SetBool("isWalking", IsWalking(in movementData));

            animationData.Container.transform.position = translation.Value;
        }).WithoutBurst().Run();

        return default;
    }

    private bool IsWalking(in MovementData movementData)
    {
        return movementData.Horizontal != 0 || movementData.Vertical != 0;
    }
}
