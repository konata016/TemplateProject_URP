using UnityEngine;
using UniRx;
using UniRx.Triggers;
using StateType = EnemyBulletStateType;

public abstract class EnemyBulletPresenterBase<M, V> : MonoBehaviour
    where M : EnemyBulletModelBase
    where V : EnemyBulletViewBase
{
    public StateController<StateType> StateController { get; private set; }

    public abstract V View { get; }

    public abstract M Model { get; }

    protected abstract void OnInitialize();
    protected abstract void BindState();

    public void Initialize()
    {
        OnInitialize();

        StateController = new StateController<StateType>();

        BindState();
        BindUpdate();
    }

    private void BindUpdate()
    {
        this.UpdateAsObservable()
            .Subscribe(observer => StateController.OnStateUpdate());
    }
}
