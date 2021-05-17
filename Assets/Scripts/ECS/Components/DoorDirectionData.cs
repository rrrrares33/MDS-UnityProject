using Unity.Entities;

public enum DoorDirection
{
    Right,
    Left,
    Bottom,
    Top,
}

[GenerateAuthoringComponent]
public struct DoorDirectionData : IComponentData
{
    public DoorDirection Value;
}
