using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;

public class MovingPlayerState : PlayerStateBase
{
    private LineRenderer lineRenderer;

    protected override void OnInitialize()
    {
        lineRenderer = view.LineRenderer;
    }

    protected override void OnStateEnter()
    {
        OnMovingAsync(view.CancellationTokenOnDestroy).Forget();
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateExit()
    {
        lineRenderer.positionCount = 0;
    }

    private async UniTask OnMovingAsync(CancellationToken token)
    {
        Tweener cameraMovingTween = null;
        for (var i = 0; i < lineRenderer.positionCount; i++)
        {
            var pos = lineRenderer.GetPosition(i);

            cameraMovingTween = MoveCamera(cameraMovingTween, pos);
            await model.Transform.DOMove(pos, 50f).SetSpeedBased();
        }

        await cameraMovingTween;

        OnFinishedMoving();
    }

    private Tweener MoveCamera(Tweener cameraMovingTween, Vector3 pos)
    {
        if (cameraMovingTween != null)
        {
            cameraMovingTween.Kill();
        }

        return InGameDefinition.MainCamera.transform.DOMoveY(pos.y, 0.3f);
    }

    private void OnFinishedMoving()
    {
        Controller.ChangeState(PlayerStateType.Idle);
    }
}
