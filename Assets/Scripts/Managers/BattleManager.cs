using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerStates { HitSlot, InputAction, Idle, }
enum EnemyStates { Action, SetStrategy, Idle, }

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
    public List<Enemy> enemies;
    public Enemy curFocusedEnemy;

    [Header("UI")]
    public GameObject UISlotMachine;
    public GameObject UIAction;

    private int enemyTurn;
    
    private void Awake() {
        player.hasTurn = false;
        enemies[0].hasTurn = true;
        enemyTurn = 0;
    }

    private void Update() {
        if(player.hasTurn){
            player.battleStateMachine.Updated();
        }
        else {
            enemies[enemyTurn].battleStateMachine.Updated();
        }
    }

    public bool SendDamage(float damage) {
        if(curFocusedEnemy == null) {
            return false;
        }
        else {
            curFocusedEnemy.ApplyDamage(damage);
            return true;
        }
    }

    public void NextTurn() {
        enemyTurn++;

        // 모든 적 턴 종료
        if(enemyTurn == enemies.Count) {
            enemyTurn = -1;
            player.hasTurn = true;
        }
        else {
            enemies[enemyTurn].hasTurn = true;
        }
        
    }


}
