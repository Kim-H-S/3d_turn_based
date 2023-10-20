using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerStates { HitSlot, InputBattleAction, Idle, }
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
    
    public Player2 player;
    public Transform[] spawnPoint;

    private List<Enemy> enemies;
    public GameObject enemyPrefab;
    private Enemy curFocusedEnemy;

    [Header("UI")]
    public SlotMachine uiSlotMachine;
    public UISlotResult uiSlotResult;
    public UIPlayerAction uiAction;
    public UIEnemyInfo uiEnemyInfo;


    [Header("Prefab")]
    public GameObject uiDamage;

    private int enemyTurn;
    private int left;
    
    private void Awake() {
        enemies = new List<Enemy>();
        left = Random.Range(0, spawnPoint.Length);

        for(int i = 0; i <= left; i++) {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint[i]);
            enemies.Add(enemy.GetComponent<Enemy>());
        }

        player.hasTurn = false;
        enemies[0].hasTurn = true;
        enemyTurn = 0;
        left += 1;
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

    public void FocusEnemy(Enemy enemy)
    {
        if(enemy == null || enemy == curFocusedEnemy)
        {
            UnfocusEnemy();
        }
        else
        {
            UnfocusEnemy();

            curFocusedEnemy = enemy;
            curFocusedEnemy.focusedLight.gameObject.SetActive(true);
            uiEnemyInfo.gameObject.SetActive(true);
            uiEnemyInfo.SetInfo(
                name: enemy.enemySO.name,
                curHP: enemy.GetCurrentHP() * enemy.enemySO.HP,
                maxHP: enemy.enemySO.HP,
                atk: enemy.enemySO.ATK,
                def: enemy.enemySO.DEF
                );
        }
    }

    private void UnfocusEnemy()
    {
        if (curFocusedEnemy == null) return;

        curFocusedEnemy.focusedLight.gameObject.SetActive(false);

        uiEnemyInfo.gameObject.SetActive(false);
        curFocusedEnemy = null;
    }

    public void KillEnemy() {
        left--;

        if(left == 0) {
            GameManager.Instance.ExitBattleScene();
        }
    }
}
