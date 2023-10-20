using UnityEngine;
using TMPro;

public class UIEnemyAction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionTxt;

    public void Updated(EnemyAction curAction)
    {
        switch(curAction)
        {
            case EnemyAction.Idle:
                actionTxt.text = "없음";
                break;
            case EnemyAction.Attack:
                actionTxt.text = "공격";
                break;
            case EnemyAction.Defence:
                actionTxt.text = "방어";
                break;
        }
    }
}
