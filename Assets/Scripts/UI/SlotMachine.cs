using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtFirstReel;
    [SerializeField] private TextMeshProUGUI txtSecondReel;
    [SerializeField] private TextMeshProUGUI txtThirdReel;

    private int firstReelResult;
    private int secondReelResult;
    private int thirdReelResult;

    [SerializeField] private Button button;

    public void OnClickPull()
    {
        button.interactable = false;

        firstReelResult = Random.Range(0, 8);
        secondReelResult = Random.Range(0, 8);
        thirdReelResult = Random.Range(0, 8);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            firstReelResult = 7;
            secondReelResult = 7;
            thirdReelResult = 7;
        }

        txtFirstReel.text = firstReelResult.ToString("D1");
        txtSecondReel.text = secondReelResult.ToString("D1");
        txtThirdReel.text = thirdReelResult.ToString("D1");

        Invoke("Hide", 1f);
    }

    void Hide()
    {
        BattleManager.Instance.uiSlotResult.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    private void OnEnable() {
        txtFirstReel.text = "-";
        txtSecondReel.text = "-";
        txtThirdReel.text = "-";

        button.interactable = true;
    }

    public float GetValue()
    {
        float value = 0.5f;

        value += (firstReelResult + secondReelResult + thirdReelResult) / 21f;

        if(firstReelResult == secondReelResult && secondReelResult == thirdReelResult)
        {
            value += 1;
        }

        return value;
    }
}
