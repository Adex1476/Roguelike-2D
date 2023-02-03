using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponSO : ItemSO
{
    public GameObject Bullet;
    public int dmg;
    public int bulletsNum;
    public float dispersionAngle;
    public int bulletLoader;
    public int currentAmmo;
    public float rateOfFire;
    public float knockback;
    public float stunTime;

    private void Awake() { itemT = itemType.Weapon; }

    public float bulletCD { get { return 1 / rateOfFire; } }
    public float bulletSplit { get { return dispersionAngle / (bulletsNum > 1 ? bulletsNum - 1 : 2); } }
}
