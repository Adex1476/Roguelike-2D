using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject item;

    private WeaponController _wc;
    private PlayerMovement _pm;

    public List<WeaponSO> weapons = new List<WeaponSO>();

    private void Start()
    {
        _wc = GetComponent<WeaponController>();
        _pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (item != null)
        {
            ItemSO i = item.GetComponent<DropScript>().itemInfo;
            addItem(i);
        }
    }

    public void addItem(ItemSO so)
    {
        switch (so.itemT)
        {
            case ItemSO.itemType.Weapon:
                if (_wc.AddWeapon((WeaponSO)so)) { Destroy(item); }
                break;
            case ItemSO.itemType.Consum:
                useConsumable((ConsumSO)so);
                Destroy(item);
                break;
            case ItemSO.itemType.Passive:
                //applyPassive((PassiveSO)so);
                Destroy(item);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) { item = collision.gameObject; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) { item = null; }
    }

    private void useConsumable(ConsumSO so)
    {
        switch (so.ct)
        {
            case (ConsumSO.consumType.Potion):
                //GameManager.Instance.Player.GetComponent<UnityEditor.U2D.Animation.CharacterData>().AddHP(item.quantity);
                break;
        }
    }
    /*
    private void applyPassive(PassiveSO so)
    {
        foreach (upModifier mod in so.mods)
        {
            switch (mod.ut)
            {
                case PassiveSO.upgradeType.MoveSpeIncrease:
                    _pm.spe *= mod.upgradeBoost;
                    break;
                case PassiveSO.upgradeType.DashCDReduction:
                    _pm.dashCD *= mod.upgradeBoost;
                    break;
                case PassiveSO.upgradeType.MaxHealthIncrease:
                    _pm.dashCD *= mod.upgradeBoost;
                    break;
            }
        }
    }*/
}