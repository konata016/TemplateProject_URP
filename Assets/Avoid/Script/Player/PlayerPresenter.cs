using UnityEngine;
using UniRx;
using UniRx.Triggers;
using StateType = PlayerStateType;

public class PlayerPresenter : MonoBehaviour
{
    [field: SerializeField] public PlayerView View { get; private set; }

    public PlayerModel Model { get; private set; }

    private StateController<StateType> stateController;

    public void Initialize()
    {
        Model = new PlayerModel(transform);
        stateController = new StateController<StateType>();

        BindState();
        BindUpdate();

        stateController.ChangeState(StateType.Idle);
    }

    private void BindUpdate()
    {
        this.UpdateAsObservable()
            .Subscribe(observer => stateController.OnStateUpdate());
    }

    private void BindState()
    {
        AddState(StateType.Void, new VoidPlayerState());
        AddState(StateType.DrawRoadRoot, new DrawRoadRootPlayerState());
        AddState(StateType.Moving, new MovingPlayerState());
        AddState(StateType.Idle, new IdlePlayerState());
    }

    private void AddState(StateType stateType, PlayerStateBase state)
    {
        state.Initialize(stateController, stateType, this);
        stateController.AddState(stateType, state);
    }
}
