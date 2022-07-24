using UnityEngine;

public class EnemyBulletView : EnemyBulletViewBase
{
    [field: SerializeField] public Renderer Renderer { get; private set; }

    public override void Initialize()
    {

    }
}
