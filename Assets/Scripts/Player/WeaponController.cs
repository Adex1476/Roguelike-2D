using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public PlayerShoot _ps;
    public int weaponNum;
    public int IndexcurrentWeapon;
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
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !GameManager.Instance.isPaused)
        {
            if (IndexcurrentWeapon > 0)
            {
                ChangeWeapon(IndexcurrentWeapon - 1);
            }         
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && !GameManager.Instance.isPaused)
        {
            if (weaponsList.Count > IndexcurrentWeapon + 1)
            {
                if (IndexcurrentWeapon == weaponNum - 1)
                {
                    ChangeWeapon(0);
                }
                else { ChangeWeapon(IndexcurrentWeapon + 1); }
            }
        }
    }

    public bool AddWeapon(WeaponSO weapon)
    {
        weaponGrabbed = true;

        if (weaponsList.Count < weaponNum)
        {
            weaponsList.Add(weapon);
            IndexcurrentWeapon = weaponsList.Count - 1;
            _ps.WeaponChange(weaponsList[IndexcurrentWeapon]);
        }
        else { weaponGrabbed = false; }
        return weaponGrabbed;
    }

    public void ChangeWeapon(int n)
    {
        IndexcurrentWeapon = n;
        if (weaponsList.Count > n)
        {
            _ps.WeaponChange(weaponsList[IndexcurrentWeapon]);
        }    
    }

    public void InstantiateCurrentWeapon(Vector2 pos)
    {
        GameObject go = Instantiate(GameManager.Instance.Item, pos, Quaternion.identity);
        go.GetComponent<DropScript>().itemInfo = weaponsList[IndexcurrentWeapon];
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