using Cysharp.Threading.Tasks;
using System.Threading;
using System;

public class IdleEnemyState : EnemyStateBase
{
    protected override void OnInitialize()
    {
    }

    protected override void OnStateEnter()
    {
        WaitTimeNextStateAsync(view.CancellationTokenOnDestroy).Forget();
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateExit()
    {
    }

    private async UniTask WaitTimeNextStateAsync(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        Controller.ChangeState(EnemyStateType.Attacking);
    }
}
