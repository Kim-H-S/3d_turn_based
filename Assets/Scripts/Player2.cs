using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : Character, ICombatable
{
    public PlayerSO playerSO; 

    public BattleStateMachine<Player2> battleStateMachine;
    

    private void Awake() {
        hpBar = GetComponentInChildren<Slider>();

        battleStateMachine = new BattleStateMachine<Player2>();
        battleStateMachine.owner = this;

        battleStateMachine.states = new State<Player2>[System.Enum.GetValues(typeof(PlayerStates)).Length];
        battleStateMachine.states[(int)PlayerStates.HitSlot] = new HitSlot();
        battleStateMachine.states[(int)PlayerStates.InputBattleAction] = new InputBattleAction();
        battleStateMachine.states[(int)PlayerStates.Idle] = new PlayerIdle();

        battleStateMachine.ChangeState((int)PlayerStates.HitSlot);

        curHP = playerSO.HP;
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

    public void ApplyDamage(float damage)
    {
        def -= damage;
        float dmg = 0;

        if (def < 0) {
            dmg = -def;
            def = 0;
        }

        curHP -= dmg;
        ShowDamageUI(dmg);

        hpBar.value = GetCurrentHP();


        if (curHP <= 0) {
            GameManager.Instance.GameOver();
        }
    }

    public float GetCurrentHP()
    {
        return curHP / playerSO.HP;
    }
}
