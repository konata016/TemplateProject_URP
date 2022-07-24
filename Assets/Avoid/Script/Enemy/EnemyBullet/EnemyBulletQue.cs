using UnityEngine;

public class EnemyBulletQue<Presenter, View, Model>
    where Presenter : EnemyBulletPresenterBase<Model, View>
    where View : EnemyBulletViewBase
    where Model : EnemyBulletModelBase
{
    private Presenter[] bulletArr;

    public EnemyBulletQue(int maxBullet)
    {
        bulletArr = new Presenter[maxBullet];
    }

    public void CreateBullet(Presenter bullet)
    {
        for (var i = 0; i < bulletArr.Length; i++)
        {
            bulletArr[i] = MonoBehaviour.Instantiate(bullet);
            InitializeBullet(bulletArr[i]);

            bulletArr[i].StateController.ChangeState(EnemyBulletStateType.Standby);
        }
    }

    public Presenter MoveStartBullet()
    {
        for (var i = 0; i < bulletArr.Length; i++)
        {
            var stateController = bulletArr[i].StateController;
            if (stateController.CurrentStateType == EnemyBulletStateType.Standby)
            {
                stateController.ChangeState(EnemyBulletStateType.Moving);
                return bulletArr[i];
            }
        }

        return null;
    }

    private void InitializeBullet(Presenter bullet)
    {
        bullet.Initialize();
    }
}
