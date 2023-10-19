using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class InputBattleAction : PlayerTurn
{
    UIPlayerAction uiAction;
    public override void Enter(Player2 Entity)
    {
        base.Enter(Entity);

        uiAction = BattleManager.Instance.uiAction;


        uiAction.gameObject.SetActive(true);
        uiAction.AttackBtn.onClick.AddListener(() => { SelectAttack(Entity); });
        uiAction.DefenceBtn.onClick.AddListener(() => { SelectDefence(Entity); });

    }

    public override void Excute(Player2 Entity)
    {
        base.Excute(Entity);

        if(uiAction.AttackBtn.image.color.a != 1)
        {
            if (BattleManager.Instance.SendDamage(Entity.GetAtk()))
            {
                Entity.battleStateMachine.ChangeState((int)PlayerStates.Idle);
            }
        }
    }

    public override void Exit(Player2 Entity)
    {
        base.Exit(Entity);

        uiAction.AttackBtn.onClick.RemoveListener(() => { SelectAttack(Entity); });
        uiAction.DefenceBtn.onClick.RemoveListener(() => { SelectDefence(Entity); });
        uiAction.gameObject.SetActive(false);
        BattleManager.Instance.FocusEnemy(null);
    }

    void SelectAttack(Player2 player)
    {
        if (BattleManager.Instance.SendDamage(player.GetAtk()))
        {
            player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
        }
    }

    void SelectDefence(Player2 player)
    {
        player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
    }
}
