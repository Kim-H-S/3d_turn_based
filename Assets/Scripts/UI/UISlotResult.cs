using UnityEngine;
using TMPro;

public class UISlotResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bonusTxt;
    [SerializeField] private TextMeshProUGUI atkTxt;
    [SerializeField] private TextMeshProUGUI defTxt;

    public void OnEnable()
    {
        float bonus = BattleManager.Instance.uiSlotMachine.GetValue();
        int atk = (int)(bonus * BattleManager.Instance.player.playerSO.ATK);
        int def = (int)(bonus * BattleManager.Instance.player.playerSO.DEF);

        bonusTxt.text = $"x {bonus.ToString("N1")}";
        atkTxt.text = atk.ToString("D1");
        defTxt.text = def.ToString("D1");
    }
}
