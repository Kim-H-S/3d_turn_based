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

    private void Update()
    {
        Display();

        Check777();
    }

    void Display()
    {
        txtFirstReel.text = firstReelResult.ToString("D1");
        txtSecondReel.text = secondReelResult.ToString("D1");
        txtThirdReel.text = thirdReelResult.ToString("D1");
    }

    void Check777()
    {
        if (firstReelResult == 7 && secondReelResult == 7 && thirdReelResult == 7)
        {
            // 777이 나오면 가장 강력하게 공격한다.
            //Debug.Log("777이 나왔습니다.");
        }
        
    }

    public void OnClickPull()
    {
        //Debug.Log("슬롯을 레버 버튼을 눌렀다.");

        button.interactable = false;

        firstReelResult = Random.Range(0, 8);
        secondReelResult = Random.Range(0, 8);
        thirdReelResult = Random.Range(0, 8);

        Invoke("Hide", 1f);
    }

    void Hide()
    {
        UIManager.Instance.canvasSlotMachine.SetActive(false);
        UIManager.Instance.canvasSlotMachine2.SetActive(true);
    }

    public int ResultNumber()
    {
        return firstReelResult * 100 + secondReelResult * 10 + thirdReelResult;
    }

    private void OnEnable() {
        firstReelResult = 0;
        secondReelResult = 0;
        thirdReelResult = 0;

        button.interactable = true;
    }
}
