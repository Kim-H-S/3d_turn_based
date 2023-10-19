using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemySO")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float HP { get; set; }
    [field: SerializeField] public float ATK { get; set; }
    [field: SerializeField] public float DEF { get; set; }
}
