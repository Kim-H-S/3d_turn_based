using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyTurn
{
    public override void Enter(Enemy Entity)
    {
        base.Enter(Entity);
        
        if(Entity.hasTurn)
        {
            Entity.hasTurn = false;
            BattleManager.Instance.NextTurn();
        }

    }

    public override void Excute(Enemy Entity)
    {
        base.Excute(Entity);
        if(Entity.hasTurn) {
            Entity.battleStateMachine.ChangeState((int)EnemyStates.Action);
        }
    }
}
