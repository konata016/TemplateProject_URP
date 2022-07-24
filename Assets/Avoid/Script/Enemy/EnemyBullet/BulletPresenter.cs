using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    private BulletBase[] bulletArr;


    public void Initialize(int maxBullet)
    {
        bulletArr = new BulletBase[maxBullet];
    }

    public void CreateBullet(BulletBase bullet)
    {
        for (var i = 0; i < bulletArr.Length; i++)
        {
            bulletArr[i] = Instantiate(bullet);
            InitializeBullet(bulletArr[i]);
        }
    }

    public void MoveStartBullet(
        float movingSpeed, 
        Vector3 position,
        Quaternion rotation)
    {
        for(var i=0;i < bulletArr.Length; i++)
        {
            if (!bulletArr[i].IsMoving)
            {
                bulletArr[i].OnEnter(movingSpeed, position, rotation);
                break;
            }
        }
    }

    private void InitializeBullet(BulletBase bullet)
    {
        bullet.Initialize();
        bullet.UpdateAsObservable().Subscribe(observer =>
        {
            if (!bullet.IsMoving)
            {
                return;
            }

            bullet.OnUpdate();

            if (!bullet.IsMoving)
            {
                bullet.OnExit();
            }
        });
    }
}
