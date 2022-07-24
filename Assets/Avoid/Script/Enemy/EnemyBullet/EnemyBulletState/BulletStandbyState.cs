using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandbyState<Model, View> :
    EnemyBulletStateBase<EnemyBulletPresenterBase<Model, View>, View, Model>
    where Model : EnemyBulletModelBase
    where View : EnemyBulletViewBase
{
    public BulletStandbyState(
        StateController<EnemyBulletStateType> controller,
        EnemyBulletStateType stateType,
        EnemyBulletPresenterBase<Model, View> presenter) :
        base(controller, stateType, presenter)
    {
    }

    protected override void OnInitialize()
    {
    }

    protected override void OnStateEnter()
    {
        view.Hide();
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateExit()
    {
    }
}
