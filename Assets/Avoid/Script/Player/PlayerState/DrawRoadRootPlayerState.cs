using UnityEngine;

public class DrawRoadRootPlayerState : PlayerStateBase
{
    private LineRenderer lineRenderer;

    protected override void OnInitialize()
    {
        lineRenderer = view.LineRenderer;
    }

    protected override void OnStateEnter()
    {
        lineRenderer.positionCount = 1;

        var pos = InGameDefinition.MainCamera.ScreenToWorldPoint(model.ScreenPoint);
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
    }

    protected override void OnStateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Draw();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Controller.ChangeState(PlayerStateType.Moving);
        }
    }

    protected override void OnStateExit()
    {
    }

    private void Draw()
    {
        var playerPositionZ = model.ScreenPoint.z;
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerPositionZ);
        var afterPosition = InGameDefinition.MainCamera.ScreenToWorldPoint(mousePosition);

        var beforePosition = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
        var dis = Vector3.SqrMagnitude(beforePosition - afterPosition);

        // àÍíËÇÃãóó£à»ì‡ÇÃèÍçáçXêVÇµÇ»Ç¢
        if (dis < 0.1f)
        {
            return;
        }

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, afterPosition);
    }
}
