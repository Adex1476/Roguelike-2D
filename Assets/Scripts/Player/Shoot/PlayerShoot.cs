using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private WeaponSO currentWeapon;
    private bool canShoot;
    private bool noAmmoLeft;
    public int currentAmmo;
    public int maxAmmo;
    public Transform target;
    protected Vector2 dir;
    private float initAngle;

    void Start()
    {
        canShoot = true;
        noAmmoLeft = false;
        maxAmmo = currentWeapon.bulletLoader;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        initAngle = Vector2.SignedAngle(Vector2.down, dir);
        transform.rotation = Quaternion.AngleAxis(initAngle, Vector3.forward);
        if (currentAmmo <= 0)
        {
            noAmmoLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot && !noAmmoLeft)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        dir = (target.position - transform.position).normalized;
        _playerRB.AddForce(-dir * currentWeapon.knockback, ForceMode2D.Impulse);
        initAngle = Vector2.SignedAngle(Vector2.down, dir) + currentWeapon.dispersionAngle / 2;
        for (int i = 0; i < currentWeapon.bulletsNum; i++)
        {
            float angle = initAngle - currentWeapon.bulletSplit * (currentWeapon.bulletsNum > 1 ? i : 1);
            Bullet bullet = Instantiate(currentWeapon.Bullet, target.position, Quaternion.AngleAxis(angle + 90, Vector3.forward)).GetComponent<Bullet>();
            bullet.Dmg = currentWeapon.dmg;
            bullet.Stun = currentWeapon.stunTime;
        }
        currentAmmo -= currentWeapon.bulletsNum;
        StartCoroutine(cdShoot());
    }

    protected IEnumerator cdShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentWeapon.bulletCD);
        canShoot = true;
    }
}