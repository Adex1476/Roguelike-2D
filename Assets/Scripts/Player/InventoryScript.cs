using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject item;

    private WeaponController _wc;
    private PlayerMovement _pm;
    [SerializeField] private GameManager _gm;

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
            case itemType.Weapon:
                if (_wc.AddWeapon((WeaponSO)so)) { Destroy(item); }
                break;
            case itemType.Consum:
                useConsumable((ConsumSO)so);
                Destroy(item);
                break;
            case itemType.Passive:
                applyPassive((PassiveSO)so);
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
                _gm.hp = _gm.maxHp;
                break;
        }
    }
    
    private void applyPassive(PassiveSO so)
    {
        foreach (upModifier mod in so.mods)
        {
            switch (mod.ut)
            {
                case upgradeType.MoveSpeIncrease:
                    _pm.spe *= mod.upgradeBoost;
                    break;
                case upgradeType.DashCDReduction:
                    _pm.dashCD *= mod.upgradeBoost;
                    break;
                case upgradeType.MaxHealthIncrease:
                    _gm.maxHp += 1;
                    break;
            }
        }
    }
}