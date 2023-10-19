using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleStateMachine<T> where T : Character
{
    public T owner;

    public State<T>[] states;
    private State<T> curState;
    public void Updated() {
        if(curState != null && owner.hasTurn) {
            curState.Excute(owner);
        }
    }

    public void ChangeState(int index) {
        if(states[index] == null) return;

        State<T> newState = states[index];

        if (curState != null) {
            curState.Exit(owner);
        }

        curState = newState;
        curState.Enter(owner);
    }
}
