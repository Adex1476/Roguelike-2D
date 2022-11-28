using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponSO : ItemSO
{
    public int dmg;
    public int bulletsNum;
    public int bulletsLeft;
    public int bulletLoader;
}
