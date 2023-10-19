using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public bool hasTurn = false; // ICombatable에 넣고 싶은데 interface라 안 들어감..
    protected float curHP;
    protected float atk;
    protected float def;
    protected Slider hpBar;

    List<GameObject> damageUiPool = new List<GameObject>();

    public float GetAtk()
    {
        return atk;
    }

    protected void ShowDamageUI(float damage)
    {
        GameObject damageUi = null;

        foreach(GameObject go in damageUiPool)
        {
            if(!go.activeSelf)
            {
                damageUi = go;
                break;
            }
        }

        if (damageUi == null)
        {
            damageUi = Instantiate(BattleManager.Instance.uiDamage);
        }

        damageUi.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), 2, 1);
        damageUi.GetComponent<UIDamage>().ShowDamage(damage);
    }
}
