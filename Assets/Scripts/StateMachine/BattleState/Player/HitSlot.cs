using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlot : PlayerTurn
{
    private SlotMachine slotMachine;

    public override void Enter(Player2 Entity)
    {
        base.Enter(Entity);
        slotMachine = BattleManager.Instance.uiSlotMachine;

        slotMachine.gameObject.SetActive(true);
    }

    public override void Excute(Player2 Entity) {
        base.Excute(Entity);

        // 슬롯 머신이 눌리고 1초 뒤, 결과 텍스트가 뜬 후로 바꿔도 될 듯
        if(!slotMachine.gameObject.activeSelf) {
            Entity.battleStateMachine.ChangeState((int)PlayerStates.InputAction);
        }
    }

    public override void Exit(Player2 Entity)
    {
        base.Exit(Entity);
        //BattleManager.Instance.slotMachine.gameObject.SetActive(false);
    }
}
