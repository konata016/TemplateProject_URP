using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBulletStateBase<Presenter, View, Model> :
    IState<EnemyBulletStateType>
    where Presenter : EnemyBulletPresenterBase<Model, View>
    where View : EnemyBulletViewBase
    where Model : EnemyBulletModelBase
{
    private Presenter presenter;

    private readonly StateController<EnemyBulletStateType> controller;
    public StateController<EnemyBulletStateType> Controller => controller;

    private readonly EnemyBulletStateType stateType;
    public EnemyBulletStateType StateType => stateType;

    protected View view => presenter.View;
    protected Model model => presenter.Model;

    protected abstract void OnInitialize();
    protected abstract void OnStateEnter();
    protected abstract void OnStateUpdate();
    protected abstract void OnStateExit();

    public EnemyBulletStateBase(
        StateController<EnemyBulletStateType> controller,
        EnemyBulletStateType stateType,
        Presenter presenter)
    {
        this.controller = controller;
        this.stateType = stateType;
        this.presenter = presenter;

        OnInitialize();
    }

    public void OnEnter()
    {
        OnStateEnter();
    }

    public void OnUpdate()
    {
        OnStateUpdate();
    }

    public void OnExit()
    {
        OnStateExit();
    }
}
