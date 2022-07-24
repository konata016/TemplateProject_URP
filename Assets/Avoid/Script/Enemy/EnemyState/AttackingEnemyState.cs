using UnityEngine;
using BulletQue = EnemyBulletQue<EnemyBulletPresenter, EnemyBulletView, EnemyBulletModel>;

public class AttackingEnemyState : EnemyStateBase
{
    private GameObject[] bulletArr = new GameObject[bulletCount];

    private Transform[] muzzleArr = new Transform[bulletCount];

    private BulletQue bulletQue;

    private static readonly int bulletCount = 3;

    protected override void OnInitialize()
    {
        var bulletDir = (bulletCount / 90f) + 45f;

        bulletQue = new BulletQue(12);

        CreateBullet();
        CreateMuzzle(bulletDir);
    }

    protected override void OnStateEnter()
    {
        Attack();
        Controller.ChangeState(EnemyStateType.Idle);
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateExit()
    {
    }

    private void CreateBullet()
    {
        var path = InGameDefinition.EnemyBulletPrefabPath;
        var prefab = Resources.Load<EnemyBulletPresenter>(path);
        bulletQue.CreateBullet(prefab);
    }

    private void CreateMuzzle(float bulletDir)
    {
        for (var i = 0; i < bulletCount; i++)
        {
            muzzleArr[i] = view.CreateGameObject($"muzzle_{i}", model.Transform).transform;
            muzzleArr[i].transform.position = view.MuzzlePosition;
            muzzleArr[i].transform.rotation = SetBulletRotation(bulletDir * i);
        }
    }

    private Quaternion SetBulletRotation(float bulletDir)
    {
        return
            Quaternion.AngleAxis(bulletDir, Vector3.forward) *
            Quaternion.AngleAxis(-45f, Vector3.forward) *
            Quaternion.AngleAxis(model.Rotation.eulerAngles.z, Vector3.forward);
    }

    private void Attack()
    {
        for (var i = 0; i < bulletCount; i++)
        {
            var bullet = bulletQue.MoveStartBullet();

            if (bullet != null)
            {
                bullet.Setup(3f, muzzleArr[i].position, muzzleArr[i].rotation);
            }
        }
    }
}
