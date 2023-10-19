using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStrategy : EnemyTurn
{
    public override void Enter(Enemy Entity)
    {
        base.Enter(Entity);

        SetNextTurnAction(Entity);
    }

    public void SetNextTurnAction(Enemy Entity)
    {
        if (Random.Range(0, 10) == 0)
        {
            Entity.SetCurAction(EnemyAction.Idle);
        }
        else if (Entity.GetCurrentHP() >= 0.7f) {
            Entity.SetCurAction(EnemyAction.Attack);
        }
        else if(Entity.GetCurrentHP() >= 0.3f) {
            if(Random.Range(0, 2) == 0) {
                Entity.SetCurAction(EnemyAction.Attack);
            }
            else {
                Entity.SetCurAction(EnemyAction.Defence);
            }
        }
        else {
            Entity.SetCurAction(EnemyAction.Attack);
        }

        Entity.battleStateMachine.ChangeState((int)EnemyStates.Idle);
    }
}
