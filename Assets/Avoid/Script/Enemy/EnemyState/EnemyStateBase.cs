
public abstract class EnemyStateBase : IState<EnemyStateType>
{
    private EnemyPresenter presenter;

    private StateController<EnemyStateType> controller;
    public StateController<EnemyStateType> Controller => controller;

    private EnemyStateType stateType;
    public EnemyStateType StateTypeNum => stateType;

    protected EnemyView view => presenter.View;
    protected EnemyModel model => presenter.Model;

    protected abstract void OnInitialize();
    protected abstract void OnStateEnter();
    protected abstract void OnStateUpdate();
    protected abstract void OnStateExit();

    public void Initialize(
        StateController<EnemyStateType> controller,
        EnemyStateType stateType,
        EnemyPresenter presenter)
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
