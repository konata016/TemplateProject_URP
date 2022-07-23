using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemyState : EnemyStateBase
{
    protected override void OnInitialize()
    {
    }

    protected override void OnStateEnter()
    {
        Attack();
        Controller.ChangeState(EnemyStateType.Idle);
    }

    protected override void OnStateUpdate()
    {
    }

    protected override void OnStateExit()
    {
    }

    private void Attack()
    {

    }
}
