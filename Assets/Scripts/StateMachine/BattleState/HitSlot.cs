using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlot : PlayerTurn
{
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);
        // 슬롯 머신 Active true, 값 000
    }

    public override void Excute(Player Entity) {
        base.Excute(Entity);
        // 슬롯 머신 작동 감지
        Debug.Log("슬롯 눌러라");

        //if(슬롯머신 값 > 000)
        Entity.battleStateMachine.ChangeState((int)PlayerState.InputAction);
    }

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);
        // 슬롯 머신 Active false
    }
}
