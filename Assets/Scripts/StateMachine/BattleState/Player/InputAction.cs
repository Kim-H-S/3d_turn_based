using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class InputAction : PlayerTurn
{
    UIPlayerAction uiAction;
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);

        uiAction = BattleManager.Instance.uiAction;


        uiAction.gameObject.SetActive(true);
        uiAction.AttackBtn.onClick.AddListener(() => { SelectAttack(Entity); });
        uiAction.DefenceBtn.onClick.AddListener(() => { SelectDefence(Entity); });

    }

    public override void Excute(Player Entity)
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

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);

        uiAction.AttackBtn.onClick.RemoveListener(() => { SelectAttack(Entity); });
        uiAction.DefenceBtn.onClick.RemoveListener(() => { SelectDefence(Entity); });
        uiAction.gameObject.SetActive(false);
        BattleManager.Instance.FocusEnemy(null);
    }

    void SelectAttack(Player player)
    {
        if (BattleManager.Instance.SendDamage(player.GetAtk()))
        {
            player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
        }
    }

    void SelectDefence(Player player)
    {
        player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
    }
}
