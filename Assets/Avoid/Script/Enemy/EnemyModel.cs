using UnityEngine;

public class EnemyModel
{
    public Vector3 Position => Transform.position;
    public Vector3 ScreenPoint =>
        InGameDefinition.MainCamera.WorldToScreenPoint(Position);

    public readonly Transform Transform;

    public EnemyModel(Transform transform)
    {
        Transform = transform;
    }
}
