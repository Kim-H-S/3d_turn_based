using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICombatable
{
    public EnemySO enemySO;
    
    // 전투 중에 바뀌는 스탯(많아지면 따로 묶어도 될 듯)
    float curHP;

    private void Awake() {
        curHP = enemySO.HP;
    }

    public void ApplyAttack() {

    }

    public void ApplyDefend() {
        
    }

    public void ApplyDamage(float damage) {
        curHP -= damage;

        if(curHP <= 0) {
            // 사망
        }
    }
}
