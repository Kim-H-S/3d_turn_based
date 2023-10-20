using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Weapon", order = 1)]
public class WeaponSO : ItemSO
{
    [Header("WeaponInfo")]

    public int attack;
}
