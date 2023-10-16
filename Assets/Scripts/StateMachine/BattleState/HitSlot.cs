using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlot : PlayerTurn
{
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);
        // 슬롯 머신 Active true
    }

    public override void Excute(Player Entity) {
        base.Excute(Entity);
        // 슬롯 머신 작동 감지
        Debug.Log("슬롯 눌러라");
    }

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);
        // 슬롯 머신 Active false
    }
}
