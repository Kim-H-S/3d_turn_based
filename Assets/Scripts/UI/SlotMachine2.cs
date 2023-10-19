using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 슬롯머신 다음에 나올 UI이다.
public class SlotMachine2 : MonoBehaviour
{
    [SerializeField] private SlotMachine slotMachine;

    [SerializeField] private TextMeshProUGUI SlotMachine_Result;

    private void Update()
    {
        SlotMachine_Result.text = slotMachine.ResultNumber().ToString();
    }
}
