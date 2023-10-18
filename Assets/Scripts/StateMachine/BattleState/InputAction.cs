using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAction : PlayerTurn
{
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);
        // 공격/방어 인풋 active true
    }

    public override void Excute(Player Entity) {
        base.Excute(Entity);
        

        Debug.Log("인풋 대기 중");
    }

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);
        // 공격/방어 인풋 active false
    }
}
