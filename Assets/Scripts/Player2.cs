using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Character, ICombatable
{
    [SerializeField] private PlayerSO playerSO; 

    public BattleStateMachine<Player2> battleStateMachine;
    

    private void Awake() {
        battleStateMachine = new BattleStateMachine<Player2>();
        battleStateMachine.owner = this;

        battleStateMachine.states = new State<Player2>[System.Enum.GetValues(typeof(PlayerStates)).Length];
        battleStateMachine.states[(int)PlayerStates.HitSlot] = new HitSlot();
        battleStateMachine.states[(int)PlayerStates.InputBattleAction] = new InputBattleAction();
        battleStateMachine.states[(int)PlayerStates.Idle] = new PlayerIdle();

        battleStateMachine.ChangeState((int)PlayerStates.HitSlot);

        curHP = 100;
    }

    public void ApplyAttack()
    {
        atk = playerSO.ATK * BattleManager.Instance.uiSlotMachine.GetValue();
    }

    public void ApplyDefend()
    {
        def = playerSO.DEF * BattleManager.Instance.uiSlotMachine.GetValue();
    }

    public void ResetStat()
    {
        atk = 0;
        def = 0;
    }

    public void ApplyDamage(float damage) {
        curHP -= damage - def;

        if(curHP <= 0) {
            // 사망
        }
    }

    public float GetAtk()
    {
        return atk;
    }
}
