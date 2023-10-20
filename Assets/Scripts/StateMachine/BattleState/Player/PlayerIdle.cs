using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerTurn
{
    public override void Enter(Player2 Entity)
    {
        base.Enter(Entity);
        
        Entity.hasTurn = false;
        
        BattleManager.Instance.NextTurn();
    }

    public override void Excute(Player2 Entity)
    {
        base.Excute(Entity);
        if(Entity.hasTurn) {
            Entity.battleStateMachine.ChangeState((int)PlayerStates.HitSlot);
        }
    }
}
