using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerTurn
{
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);
        
        Entity.hasTurn = false;
        
        BattleManager.Instance.NextTurn();
    }

    public override void Excute(Player Entity)
    {
        base.Excute(Entity);
        if(Entity.hasTurn) {
            Entity.battleStateMachine.ChangeState((int)PlayerStates.HitSlot);
        }
    }
}
