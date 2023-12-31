using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State<Player2>
{
    public override void Enter(Player2 Entity) {
        // 몬스터 Info 창 active true
    }

    public override void Excute(Player2 Entity) {
        // 적 클릭
        if (Input.GetMouseButtonUp(0))
        {
            // 카메라에서 레이저를 쏜다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // 레이저에 적이 맞았다면
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 50, 1 << LayerMask.NameToLayer("Enemy")))
            {
                GameObject go = raycastHit.collider.gameObject;

                Enemy enemy = go.GetComponent<Enemy>();
                BattleManager.Instance.FocusEnemy(enemy);
            }
        }
    }

    public override void Exit(Player2 Entity) {
        // 몬스터 Info 창 active false
    }
}
