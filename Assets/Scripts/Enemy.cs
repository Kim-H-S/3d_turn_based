using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, ICombatable
{
    public EnemySO enemySO;
    

    private void Awake() {
        //curHP = enemySO.HP;
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
