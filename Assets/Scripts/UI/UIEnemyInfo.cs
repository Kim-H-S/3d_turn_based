using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEnemyInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI Atk;
    [SerializeField] private TextMeshProUGUI Def;

    public void SetInfo(string name, float curHP, float maxHP, float atk, float def)
    {
        Name.text = name;
        HP.text = $"{curHP} / {maxHP}";
        Atk.text = ((int)atk).ToString();
        Def.text = ((int)def).ToString();
    }
}
