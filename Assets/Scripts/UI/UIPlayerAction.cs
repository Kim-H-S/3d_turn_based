using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerAction : MonoBehaviour
{
    Player player;
    [SerializeField] private Button AttackBtn; 
    [SerializeField] private Button DefenceBtn; 

    private void Awake() {
        player = BattleManager.Instance.player;
        AttackBtn.onClick.AddListener(OnClickAttackButton);
        DefenceBtn.onClick.AddListener(OnClickDefenceButton);
    }

    void OnClickAttackButton() {
        player.ApplyAttack();
        player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
    }

    void OnClickDefenceButton() {
        player.ApplyDefend();
        player.battleStateMachine.ChangeState((int)PlayerStates.Idle);
    }
}
