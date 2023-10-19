using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAction : PlayerTurn
{
    public override void Enter(Player Entity)
    {
        base.Enter(Entity);
    
        BattleManager.Instance.UIAction.SetActive(true);
    }

    public override void Exit(Player Entity)
    {
        base.Exit(Entity);
        
        BattleManager.Instance.UIAction.SetActive(false);
    }
}
