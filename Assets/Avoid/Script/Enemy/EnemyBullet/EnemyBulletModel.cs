using UnityEngine;

public class EnemyBulletModel : EnemyBulletModelBase
{
    public float MovingSpeed { get; private set; }

    public EnemyBulletModel(Transform transform) : base(transform)
    {

    }

    public void SetMovingSpeed(float speed)
    {
        MovingSpeed = speed;
    }
}
