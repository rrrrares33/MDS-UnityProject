using Unity.Entities;

[GenerateAuthoringComponent]
public struct ChasePlayerData : IComponentData
{
    public float StopAtDistance;
}
