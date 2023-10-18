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

        // if 인풋(공격)
        // SendDamage(Entity.ApplyAttack)

        // else if 방어
        // Entity.ApplyDefend();

        // Idle 상태로 전환
    }

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);
        // 공격/방어 인풋 active false
    }
}
