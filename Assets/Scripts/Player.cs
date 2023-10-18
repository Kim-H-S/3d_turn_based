using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { HitSlot, InputAction, }

public class Player : Character, ICombatable
{
    public BattleStateMachine<Player> battleStateMachine;
    

    private void Awake() {
        battleStateMachine = new BattleStateMachine<Player>();
        battleStateMachine.owner = this;

        battleStateMachine.states = new State<Player>[System.Enum.GetValues(typeof(PlayerState)).Length];
        battleStateMachine.states[(int)PlayerState.HitSlot] = new HitSlot();
        battleStateMachine.states[(int)PlayerState.InputAction] = new InputAction();

        battleStateMachine.ChangeState((int)PlayerState.HitSlot);

        curHP = 100;
    }

    public void ApplyAttack() {

    }

    public void ApplyDefend() {
        
    }

    public void ApplyDamage(float damage) {
        curHP -= damage;

        if(curHP <= 0) {
            // 사망
        }
    }
}
