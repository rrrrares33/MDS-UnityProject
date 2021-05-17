using System;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct MovementData : IComponentData
{
    [NonSerialized] public float Horizontal;
    [NonSerialized] public float Vertical;

    public float Speed;
    public float DiagonalSpeedMultiplier;
}
