using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private PlayerShoot _ps;
    public int weaponNum;
    public int currentWeapon;
    public WeaponSO initWeapon;
    public List<WeaponSO> weaponsList = new List<WeaponSO>();
    public Sprite empty;
    bool weaponGrabbed;


    // Start is called before the first frame update
    void Start()
    {
        AddWeapon(initWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon == 0)
            {
                ChangeWeapon(weaponNum - 1);
            } 
            else { ChangeWeapon(currentWeapon - 1); }          
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon == weaponNum - 1)
            {
                ChangeWeapon(0);
            }
            else { ChangeWeapon(currentWeapon + 1); }
        }
        if (Input.GetKeyDown(KeyCode.X)) { DropWeapon(); }
    }

    public bool AddWeapon(WeaponSO weapon)
    {
        weaponGrabbed = true;

        if (weaponsList.Count < weaponNum)
        {
            weaponsList.Add(weapon);
            currentWeapon = weaponsList.Count - 1;
            _ps.WeaponChange(weaponsList[currentWeapon]);
        }
        else { weaponGrabbed = false; }
        return weaponGrabbed;
    }

    public void ChangeWeapon(int n)
    {
        currentWeapon = n;
        if (weaponsList.Count > n)
        {
            _ps.WeaponChange(weaponsList[currentWeapon]);
        }    
        else { _ps.WeaponDelete(); }
    }

    public void DropWeapon()
    {
        if (currentWeapon < weaponsList.Count)
        {
            Vector2 dropPosition = new Vector2(transform.position.x + 1, transform.position.y);
            InstantiateCurrentWeapon(dropPosition);
            weaponsList.RemoveAt(currentWeapon);
            _ps.WeaponDelete();
        }
    }

    public void InstantiateCurrentWeapon(Vector2 pos)
    {
        GameObject go = Instantiate(GameManager.Instance.Item, pos, Quaternion.identity);
        go.GetComponent<DropScript>().itemInfo = weaponsList[currentWeapon];
    }

    public Sprite weaponImg(int m)
    {
        if (m < weaponsList.Count)
        {
            return weaponsList[m].img;
        } 
        else { return empty; }
    }
}