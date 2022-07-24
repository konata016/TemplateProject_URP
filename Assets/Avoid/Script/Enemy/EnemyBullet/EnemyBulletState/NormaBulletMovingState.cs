using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class NormaBulletMovingState :
    EnemyBulletStateBase<EnemyBulletPresenter, EnemyBulletView, EnemyBulletModel>
{
    public NormaBulletMovingState(
        StateController<EnemyBulletStateType> controller,
        EnemyBulletStateType stateType,
        EnemyBulletPresenter presenter) :
        base(controller, stateType, presenter)
    {
    }

    protected override void OnInitialize()
    {
        view.Renderer.OnBecameInvisibleAsObservable().Subscribe((x) => OnOffscreen());
    }

    protected override void OnStateEnter()
    {
        view.Show();
    }

    protected override void OnStateUpdate()
    {
       model.Transform.Translate(model.Transform.up * model.MovingSpeed * Time.deltaTime, Space.World);
    }

    protected override void OnStateExit()
    {
        view.Hide();
    }

    private void OnOffscreen()
    {
        if (Controller.CurrentStateType == StateType)
        {
            Controller.ChangeState(EnemyBulletStateType.Standby);
        }
    }
}
