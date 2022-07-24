using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateType = EnemyBulletStateType;
using StandbyState = BulletStandbyState<EnemyBulletModel, EnemyBulletView>;

public class EnemyBulletPresenter :
    EnemyBulletPresenterBase<EnemyBulletModel, EnemyBulletView>
{
    [SerializeField] private EnemyBulletView view;
    private EnemyBulletModel model;

    public override EnemyBulletView View => view;

    public override EnemyBulletModel Model => model;

    protected override void OnInitialize()
    {
        model = new EnemyBulletModel(transform);
    }

    protected override void BindState()
    {
        var standbyState = new StandbyState(StateController, StateType.Standby, this);
        StateController.AddState(StateType.Standby, standbyState);

        var movingState = new NormaBulletMovingState(StateController, StateType.Moving, this);
        StateController.AddState(StateType.Moving, movingState);
    }

    public void Setup(float movingSpeed, Vector3 position, Quaternion rotation)
    {
        View.SetPosition(position);
        View.SetRotation(rotation);
        Model.SetMovingSpeed(movingSpeed);
    }
}
