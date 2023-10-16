using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { HitSlot, InputAction, }
public enum EnemyStates {  }

public class BattleStateMachine : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    private State<Player>[] playerStates;
    private State<Enemy>[] enemyStates;
    private State<Player> curPlayerState;
    private State<Enemy> curEnemyState;

    private void Awake() {
        // 플레이어 턴 상태
        playerStates = new State<Player>[(int)System.Enum.GetValues(typeof(PlayerStates)).Length];
        playerStates[(int)PlayerStates.HitSlot] = new HitSlot();
        playerStates[(int)PlayerStates.InputAction] = new InputAction();

        ChangePlayerState(PlayerStates.HitSlot);
        
        // 몬스터 턴 상태
        enemyStates = new State<Enemy>[(int)System.Enum.GetValues(typeof(EnemyStates)).Length];
        //enemyStates[0] = new 
    }

    private void Update() {
        if(curPlayerState != null) {
            curPlayerState.Excute(player);
        }
    }

    private void ChangePlayerState(PlayerStates newState) {
        if(playerStates[(int)newState] == null) return;

        if (curPlayerState != null) {
            curPlayerState.Exit(player);
        }

        curPlayerState = playerStates[(int)newState];
        curPlayerState.Enter(player);
    }

    private void ChangeEnemyState(EnemyStates newState) {
        if(enemyStates[(int)newState] == null) return;

        if (curEnemyState != null) {
            curEnemyState.Exit(enemy);
        }

        curEnemyState = enemyStates[(int)newState];
        curEnemyState.Enter(enemy);
    }
}
