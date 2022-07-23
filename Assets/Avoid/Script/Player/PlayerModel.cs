using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public Vector3 Position => Transform.position;
    public Vector3 ScreenPoint =>
        InGameDefinition.MainCamera.WorldToScreenPoint(Position);

    public readonly Transform Transform;

    public PlayerModel(Transform transform)
    {
        Transform = transform;
    }
}
