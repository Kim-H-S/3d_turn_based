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
        if(Entity.GetCurrentHP() >= 0.7f) {
            Debug.Log($"{Entity.name}: 공격 예정");
            Entity.curAction = EnemyAction.Attack;
        }
        else if(Entity.GetCurrentHP() >= 0.3f) {
            if(Random.Range(0, 2) == 0) {
                Debug.Log($"{Entity.name}: 공격 예정");
                Entity.curAction = EnemyAction.Attack;
            }
            else {
                Debug.Log($"{Entity.name}: 방어 예정");
                Entity.curAction = EnemyAction.Defence;
            }
        }
        else {
            Debug.Log($"{Entity.name}: 공격 예정");
            Entity.curAction = EnemyAction.Attack;
        }

        Entity.battleStateMachine.ChangeState((int)EnemyStates.Idle);
    }
}
