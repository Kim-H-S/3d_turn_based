using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerAction : MonoBehaviour
{
    Player2 player;
    public Button AttackBtn; 
    public Button DefenceBtn;

    Color UnseletedAlphaValue = new Color(1, 1, 1, 1);
    Color SeletedAlphaValue = new Color(1, 1, 1, 0.6f);

    private void Awake() {
        player = BattleManager.Instance.player;

        AttackBtn.onClick.AddListener(() => { ToggleAlphaValueButton(AttackBtn); });
        DefenceBtn.onClick.AddListener(() => { ToggleAlphaValueButton(DefenceBtn); });
    }

    void ToggleAlphaValueButton(Button btn)
    {
        if(btn.image.color == UnseletedAlphaValue)
        {
            btn.image.color = SeletedAlphaValue;
        }
        else
        {
            btn.image.color = UnseletedAlphaValue;
        }
    }

    private void OnEnable()
    {
        AttackBtn.image.color = UnseletedAlphaValue;
        DefenceBtn.image.color = UnseletedAlphaValue;
    }
}
