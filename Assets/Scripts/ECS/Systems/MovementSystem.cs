using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;

[AlwaysSynchronizeSystem]
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        return Entities.ForEach((ref PhysicsVelocity velocity, in MovementData movementData) =>
        {
            velocity.Linear.x += movementData.Horizontal * movementData.Speed * deltaTime;
            velocity.Linear.y += movementData.Vertical * movementData.Speed * deltaTime;
        }).Schedule(inputDeps);
    }
}
