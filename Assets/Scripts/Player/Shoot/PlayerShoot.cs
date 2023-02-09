using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private WeaponSO currentWeapon;
    [SerializeField] private WeaponSelectorUI weaponUI;
    [SerializeField] private WeaponController _wc;
    private bool canShoot;
    private bool noAmmoLeft;
    public int _currentAmmo;
    public int _maxAmmo;
    public Transform target;
    protected Vector2 dir;
    private float initAngle;

    void Awake()
    {
        canShoot = true;
        noAmmoLeft = false;
        _maxAmmo = currentWeapon.bulletLoader;
        _currentAmmo = _maxAmmo;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        initAngle = Vector2.SignedAngle(Vector2.down, dir);
        transform.rotation = Quaternion.AngleAxis(initAngle, Vector3.forward);
        if (_currentAmmo <= 0)
        {
            noAmmoLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        { 
            _currentAmmo = _maxAmmo;
            _wc.weaponsList[_wc.IndexcurrentWeapon].currentAmmo = currentWeapon.bulletLoader;
            noAmmoLeft = false;
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
        _wc.weaponsList[_wc.IndexcurrentWeapon].currentAmmo  -= currentWeapon.bulletsNum;
        _currentAmmo = _wc.weaponsList[_wc.IndexcurrentWeapon].currentAmmo;
        StartCoroutine(cdShoot());
    }

    public void WeaponChange(WeaponSO weapon)
    {
        currentWeapon = weapon;
        canShoot = true;
        noAmmoLeft = false;
        _maxAmmo = currentWeapon.bulletLoader;
        _currentAmmo = _wc.weaponsList[_wc.IndexcurrentWeapon].currentAmmo;
        weaponUI.UpdateWeaponUI();
    }

    protected IEnumerator cdShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentWeapon.bulletCD);
        canShoot = true;
    }
}
