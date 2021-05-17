using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
    public KeyCode MoveUp;
    public KeyCode MoveLeft;
    public KeyCode MoveDown;
    public KeyCode MoveRight;

    public KeyCode AttackUp;
    public KeyCode AttackLeft;
    public KeyCode AttackDown;
    public KeyCode AttackRight;
}
