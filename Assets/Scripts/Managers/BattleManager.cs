using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;
    public static BattleManager Instance
    {
        get
        {
            if(instance == null) {
                instance = FindObjectOfType<BattleManager>();

                if(instance == null) {
                    GameObject go = new GameObject(name: "BattleManager");
                    instance = go.AddComponent<BattleManager>();
                }
            }

            return instance;
        }
    }
    
    public Player player;
    public List<Enemy> enemy;

    public SlotMachine slotMachine;
    private int slotMachineValue;
    
    private void Update() {
        player.battleStateMachine.Updated();
    }

    void ChangeSlotMachineValue(int value) {
        slotMachineValue = value;
    }
}
