using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerMovementData : IComponentData
{
    public float horizontal;
    public float vertical;
    public float speed;
    public float diagonalSpeedDecrease;
}
