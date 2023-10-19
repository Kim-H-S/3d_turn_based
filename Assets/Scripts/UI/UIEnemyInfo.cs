using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEnemyInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private Slider HP;
    [SerializeField] private TextMeshProUGUI Atk;
    [SerializeField] private TextMeshProUGUI Def;

    public void SetInfo(string name, float remainHp, float atk, float def)
    {
        Name.text = name;
        HP.value = remainHp;
        Atk.text = ((int)atk).ToString();
        Def.text = ((int)def).ToString();
    }
}
