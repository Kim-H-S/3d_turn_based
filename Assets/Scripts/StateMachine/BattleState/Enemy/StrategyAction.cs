using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyAction : EnemyTurn
{
    public override void Enter(Enemy Entity)
    {
        base.Enter(Entity);

        ActOnStrategy(Entity);
    }

    void ActOnStrategy(Enemy Entity) {
        switch(Entity.curAction) {
            case EnemyAction.Idle:
                Debug.Log("아무것도 안 함");
                break;
            case EnemyAction.Attack:
                Entity.ApplyAttack();
                break;
            case EnemyAction.Defence:
                Entity.ApplyDefend();
                break;
        }

        Entity.battleStateMachine.ChangeState((int)EnemyStates.SetStrategy);
    }
}
