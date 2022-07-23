using UnityEngine;
using UniRx;
using UniRx.Triggers;
using StateType = EnemyStateType;

public class EnemyPresenter : MonoBehaviour
{
    [field: SerializeField] public EnemyView View { get; private set; }

    public EnemyModel Model { get; private set; }

    private StateController<StateType> stateController;

    public void Initialize()
    {
        Model = new EnemyModel(transform);
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
        AddState(StateType.Idle, new IdleEnemyState());
        AddState(StateType.Attacking, new AttackingEnemyState());
    }

    private void AddState(StateType stateType, EnemyStateBase state)
    {
        state.Initialize(stateController, stateType, this);
        stateController.AddState(stateType, state);
    }
}
