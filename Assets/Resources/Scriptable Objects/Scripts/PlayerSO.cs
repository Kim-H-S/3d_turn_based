using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public float HP { get; set; }
    [field: SerializeField] public float ATK { get; set; }
    [field: SerializeField] public float DEF { get; set; }
}
