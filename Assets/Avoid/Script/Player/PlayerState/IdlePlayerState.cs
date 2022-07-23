using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdlePlayerState : PlayerStateBase
{
    protected override void OnInitialize()
    {
    }

    protected override void OnStateEnter()
    {
    }

    protected override void OnStateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFinishedMoving();
        }
    }

    protected override void OnStateExit()
    {
    }

    private void OnFinishedMoving()
    {
        Controller.ChangeState(PlayerStateType.DrawRoadRoot);
    }
}
