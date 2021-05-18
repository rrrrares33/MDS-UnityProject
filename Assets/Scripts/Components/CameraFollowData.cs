using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public class CameraFollowData : IComponentData
{
    public Camera Value;
}
