using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAction : PlayerTurn
{
    public override void Excute(Player Entity) {
        base.Excute(Entity);
        // 공격, 방어 인풋 감지
    }
}
