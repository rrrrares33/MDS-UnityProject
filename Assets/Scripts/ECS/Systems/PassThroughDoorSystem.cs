using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class PassThroughDoorSystem : JobComponentSystem
{
    private BuildPhysicsWorld BuildPhysicsWorldSystem;
    private StepPhysicsWorld StepPhysicsWorldSystem;

    protected override void OnCreate()
    {
        BuildPhysicsWorldSystem = World.GetOrCreateSystem<BuildPhysicsWorld>();
        StepPhysicsWorldSystem = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    [BurstCompile]
    private struct TriggerEventPassThroughDoor : ITriggerEventsJob
    {
        [ReadOnly] public ComponentDataFromEntity<DoorDirectionData> DoorGroup;

        [ReadOnly] public ComponentDataFromEntity<PlayerTag> PlayerGroup;
        public ComponentDataFromEntity<Translation> TranslationGroup;

        public void Execute(TriggerEvent triggerEvent)
        {
            Entity entityA = triggerEvent.EntityA;
            Entity entityB = triggerEvent.EntityB;

            bool isEntityADoor = DoorGroup.HasComponent(entityA);
            bool isEntityBDoor = DoorGroup.HasComponent(entityB);

            bool isEntityAPlayer = PlayerGroup.HasComponent(entityA) && TranslationGroup.HasComponent(entityA);
            bool isEntityBPlayer = PlayerGroup.HasComponent(entityB) && TranslationGroup.HasComponent(entityB);

            if (isEntityADoor && isEntityBPlayer)
            {
                Entity aux = entityA;
                entityA = entityB;
                entityB = aux;
            }
            if (isEntityAPlayer && isEntityBDoor)
            {
                Translation playerTranslation = TranslationGroup[entityA];

                switch (DoorGroup[entityB].Value)
                {
                    case DoorDirection.Right:
                        playerTranslation.Value.x += 5;
                        break;

                    case DoorDirection.Left:
                        playerTranslation.Value.x -= 5;
                        break;

                    case DoorDirection.Bottom:
                        playerTranslation.Value.y -= 5;
                        break;

                    case DoorDirection.Top:
                        playerTranslation.Value.y += 5;
                        break;
                }

                TranslationGroup[entityA] = playerTranslation;
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return new TriggerEventPassThroughDoor
        {
            DoorGroup = GetComponentDataFromEntity<DoorDirectionData>(true),
            PlayerGroup = GetComponentDataFromEntity<PlayerTag>(true),
            TranslationGroup = GetComponentDataFromEntity<Translation>()
        }.Schedule(StepPhysicsWorldSystem.Simulation, ref BuildPhysicsWorldSystem.PhysicsWorld, inputDeps);
    }
}
