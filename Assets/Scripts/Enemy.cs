using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAction { Idle, Attack, Defence }

public class Enemy : Character, ICombatable
{
    public EnemySO enemySO;
    public BattleStateMachine<Enemy> battleStateMachine;
    public EnemyAction curAction;
    

    private void Awake() {
        battleStateMachine = new BattleStateMachine<Enemy>();
        battleStateMachine.owner = this;

        battleStateMachine.states = new State<Enemy>[System.Enum.GetValues(typeof(EnemyStates)).Length];
        battleStateMachine.states[(int)EnemyStates.Action] = new StrategyAction();
        battleStateMachine.states[(int)EnemyStates.SetStrategy] = new SetStrategy();
        battleStateMachine.states[(int)EnemyStates.Idle] = new EnemyIdle();

        battleStateMachine.ChangeState((int)EnemyStates.Idle);
        curHP = enemySO.HP;
        curAction = EnemyAction.Idle;
    }

    public void ApplyAttack() {
        Debug.Log("공격!");
    }

    public void ApplyDefend() {
        Debug.Log("방어!");
    }

    public void ApplyDamage(float damage) {
        curHP -= damage;

        if(curHP <= 0) {
            // 사망
        }
    }

    public void SetAnimWithAction() {

    }

    public float GetCurrentHP() {
        return curHP / enemySO.HP;
    }
}
