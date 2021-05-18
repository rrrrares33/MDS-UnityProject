using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public class FollowCameraData : IComponentData
{
    public Camera Value;
}
