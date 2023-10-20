using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyAction : EnemyTurn
{
    public override void Enter(Enemy Entity)
    {
        base.Enter(Entity);

        Entity.ResetStat();
        ActOnStrategy(Entity);
    }

    void ActOnStrategy(Enemy Entity) {
        switch(Entity.CurAction) {
            case EnemyAction.Attack:
                Entity.ApplyAttack();
                BattleManager.Instance.player.ApplyDamage(Entity.GetAtk());
                break;
            case EnemyAction.Defence:
                Entity.ApplyDefend();
                break;
        }

        Entity.battleStateMachine.ChangeState((int)EnemyStates.SetStrategy);
    }
}
