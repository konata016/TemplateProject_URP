using UnityEngine;

public class EnemyBulletModelBase
{
    public Vector3 Position => Transform.position;
    public Vector3 ScreenPoint =>
        InGameDefinition.MainCamera.WorldToScreenPoint(Position);

    public Quaternion Rotation => Transform.rotation;

    public readonly Transform Transform;

    public EnemyBulletModelBase(Transform transform)
    {
        Transform = transform;
    }
}
