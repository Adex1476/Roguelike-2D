using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private WeaponSO currentWeapon;
    public Transform target;
    protected Vector2 dir;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        angle = Vector2.SignedAngle(Vector2.down, dir);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        BulletMove bullet = Instantiate(_bulletPrefab, target.position, Quaternion.identity).GetComponent<BulletMove>();
        bullet.Dmg = currentWeapon.dmg;
    }
}