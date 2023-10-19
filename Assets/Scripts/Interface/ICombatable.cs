using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatable
{
    void ApplyAttack();
    void ApplyDefend();
    void ApplyDamage(float damage);
}
