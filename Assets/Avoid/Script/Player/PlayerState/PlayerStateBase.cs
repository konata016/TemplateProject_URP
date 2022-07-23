
public abstract class PlayerStateBase : IState<PlayerStateType>
{
    private PlayerPresenter presenter;

    private StateController<PlayerStateType> controller;
    public StateController<PlayerStateType> Controller => controller;

    private PlayerStateType stateType;
    public PlayerStateType StateTypeNum => stateType;

    protected PlayerView view => presenter.View;
    protected PlayerModel model => presenter.Model;

    protected abstract void OnInitialize();
    protected abstract void OnStateEnter();
    protected abstract void OnStateUpdate();
    protected abstract void OnStateExit();

    public void Initialize(
        StateController<PlayerStateType> controller,
        PlayerStateType stateType,
        PlayerPresenter presenter)
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
